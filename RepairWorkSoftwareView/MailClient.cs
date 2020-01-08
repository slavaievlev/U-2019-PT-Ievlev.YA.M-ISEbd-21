using System;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using System.Windows.Forms;
using OpenPop.Pop3;
using RepairWorkSoftwareDAL.BindingModel;
using Message = OpenPop.Mime.Message;

namespace RepairWorkSoftwareView
{
    public class MailClient
    {
        private static TcpClient _mailClient;
        private static SslStream _stream;
        private static StreamReader _reader;
        private static StreamWriter _writer;

        public static void ConnectWithOpenPopLibrary()
        {
            var popClient = new Pop3Client();
            popClient.Connect("pop.gmail.com", 995, true);
            popClient.Authenticate(WebConfigurationManager.AppSettings["MailLogin"],
                WebConfigurationManager.AppSettings["MailPassword"]);

            int messageCount = popClient.GetMessageCount();
            for (int count = 1; count < messageCount; count++)
            {
                Message message = popClient.GetMessage(count);
                Console.WriteLine(message.Headers);
                // ApiClient.PostRequest<MessageInfoBindingModel, bool>("api/MessageInfo/AddElement",
                //     new MessageInfoBindingModel
                //     {
                //         MessageId = Convert.ToString(count),
                //         FromMailAddress = from,
                //         DateDelivery = Convert.ToDateTime(date),
                //         Subject = orderSubjectMessage,
                //         Body = orderBodyMessage
                //     });
            }
        }
        
        public static void Connect()
        {
            string response = null;

            _mailClient = new TcpClient();
            _mailClient.Connect("pop.gmail.com", 995);
            
            _stream = new SslStream(_mailClient.GetStream());
            _stream.AuthenticateAsClient("pop.gmail.com");
            
            _reader = new StreamReader(_stream, Encoding.ASCII);
            _writer = new StreamWriter(_stream);

            response = _reader.ReadLine();
            response = SendRequest(_reader, _writer,
                string.Format("USER {0}", WebConfigurationManager.AppSettings["MailLogin"]),
                "Ошибка авторизации, неверный логин");

            response = SendRequest(_reader, _writer, string.Format("PASS {0}",
                    WebConfigurationManager.AppSettings["MailPassword"]),
                "Ошибка авторизации, неверный пароль");

            CheckMail();
        }

        private static void CheckMail()
        {
            string response = null;

            try
            {
                response = SendRequest(_reader, _writer,
                    string.Format("stat"), "Ошибка. Неизвестная команда (stat)");

                string[] numbers = Regex.Split(response, @"\D+");

                int number = Convert.ToInt32(numbers[1]);

                if (number > 0)
                {
                    GetMessage(number);
                }

                response = SendRequest(_reader, _writer,
                    string.Format("Quit"),
                    "Ошибка. Неизвестная команда (Quit)");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string SendRequest(StreamReader reader, StreamWriter writer, string message, string errorMessage)
        {
            writer.WriteLine(message);
            writer.Flush();
            var response = reader.ReadLine();
            if (response.StartsWith("-ERR"))
            {
                throw new Exception(errorMessage);
            }

            return response;
        }

        private static void GetMessage(int number)
        {
            string response = SendRequest(_reader, _writer,
                string.Format("RETR {0}", number),
                "Ошибка. Не удалось получить письмо");

            string messageId = string.Empty;
            string from = string.Empty;
            string orderSubjectMessage = string.Empty;
            string orderBodyMessage = string.Empty;
            string date = string.Empty;
            string coding = string.Empty;

            while (true)
            {
                response = _reader.ReadLine();
                if (response == ".")
                    break;
                if (response.Length > 4)
                {
                    if (response.StartsWith("From:"))
                    {
                        from = response.Substring(6);
                    }

                    if (response.StartsWith("Date:"))
                    {
                        date = response.Substring(6);
                    }

                    if (response.StartsWith("Message-ID: "))
                    {
                        messageId = response.Substring(12);
                    }

                    if (response.StartsWith("Subject:"))
                    {
                        orderSubjectMessage = GetSubject(ref response, ref coding);

                        orderBodyMessage = GetBody(response, coding);
                    }

                    if (!string.IsNullOrEmpty(messageId)
                        && !string.IsNullOrEmpty(from)
                        && !string.IsNullOrEmpty(orderSubjectMessage)
                        && !string.IsNullOrEmpty(date))
                    {
                        ApiClient.PostRequest<MessageInfoBindingModel, bool>("api/MessageInfo/AddElement",
                            new MessageInfoBindingModel
                            {
                                MessageId = messageId,
                                FromMailAddress = from,
                                DateDelivery = Convert.ToDateTime(date),
                                Subject = orderSubjectMessage,
                                Body = orderBodyMessage
                            });

                        messageId = string.Empty;
                        from = string.Empty;
                        date = string.Empty;
                        orderSubjectMessage = string.Empty;
                        orderBodyMessage = string.Empty;
                    }
                }
            }
        }

        private static string GetSubject(ref string response, ref string coding)
        {
            StringBuilder subject = new StringBuilder(response);
            while (!response.StartsWith("To:"))
            {
                response = _reader.ReadLine();
                subject.Append(response);
            }

            MatchCollection rr = Regex.Matches(subject.ToString(),
                @"(?:=\?)([^\?]+)(?:\?B\?)([^\?]*)(?:\?=)");
            if (rr.Count > 0)
            {
                coding = rr[0].Groups[1].Value;
                string message = rr[0].Groups[2].Value;
                byte[] b = Convert.FromBase64String(message);
                return Encoding.GetEncoding(coding).GetString(b);
            }
            else
            {
                return subject.ToString();
            }
        }

        private static string GetBody(string response, string coding)
        {
            while (!response.StartsWith("Content-Type: text/plain") && response != ".")
            {
                response = _reader.ReadLine();
            }

            response = _reader.ReadLine();
            StringBuilder bodyMessage = new StringBuilder();
            
            bool needEncoding = false;
            if (response.StartsWith("Content-Transfer-Encoding:"))
            {
                needEncoding = true;
                response = _reader.ReadLine();
            }

            while (!response.StartsWith("--"))
            {
                bodyMessage.Append(response);
                response = _reader.ReadLine();
            }

            if (needEncoding)
            {
                byte[] b = Convert.FromBase64String(bodyMessage.ToString());
                return Encoding.UTF8.GetString(b);
                // return Encoding.GetEncoding(coding).GetString(b);
            }
            else
            {
                return bodyMessage.ToString();
            }
        }
    }
}