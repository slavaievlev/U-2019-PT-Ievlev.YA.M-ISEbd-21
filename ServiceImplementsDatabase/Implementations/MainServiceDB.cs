using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Net.Mail;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using RepairWorkSoftwareModel;

namespace ServiceImplementsDatabase.Implementations
{
    public class MainServiceDB : IMainService
    {
        private readonly AbstractDbContext _context;

        public MainServiceDB(AbstractDbContext context)
        {
            _context = context;
        }
        public List<OrderViewModel> GetList()
        {
            List<OrderViewModel> result = _context.Orders.Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                CustomerId = rec.CustomerId,
                WorkId = rec.WorkId,
                DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
                    SqlFunctions.DateName("mm", rec.DateCreate) + " " +
                    SqlFunctions.DateName("yyyy", rec.DateCreate),
                DateImplement = rec.DateImplement == null ? "" :
                    SqlFunctions.DateName("dd", rec.DateImplement.Value) + " " +
                    SqlFunctions.DateName("mm", rec.DateImplement.Value) + " " +
                    SqlFunctions.DateName("yyyy", rec.DateImplement.Value),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                CustomerFIO = rec.Customer.CustomerFIO,
                WorkName = rec.Work.WorkName,
                ImplementerName = rec.Implementer.Fio
            })
                .ToList();
            return result;
        }

        public List<OrderViewModel> GetFreeOrders()
        {
            return _context.Orders
                .Where(o => o.Status == OrderStatus.Принят || o.Status == OrderStatus.НедостаточноРусурсов)
                .Select(o => new OrderViewModel
                {
                    Id = o.Id
                })
                .ToList();
        }

        public void CreateOrder(OrderBindingModel model)
        {
            var order = new Order
            {
                CustomerId = model.CustomerId,
                WorkId = model.WorkId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            };
            _context.Orders.Add(order);
            _context.SaveChanges();

            var customer = _context.Customers.FirstOrDefault(x => x.Id == model.CustomerId);
            SendEmail(customer.Mail, "Оповещение по заказам",
                string.Format("Заказ №{0} от {1} создан успешно", order.Id, order.DateCreate.ToShortDateString()));
            
        }
        public void TakeOrderInWork(OrderBindingModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                Order element = _context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                try
                {
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if (element.Status != OrderStatus.Принят)
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    var productComponents = _context.WorkMaterials.Include(rec => rec.Material).Where(rec => rec.WorkId == element.WorkId);                  

                    foreach (var productComponent in productComponents)
                    {
                        int countOnStocks = productComponent.Count * element.Count;
                        var stockComponents = _context.StockMaterials.Where(rec =>
                        rec.MaterialId == productComponent.MaterialId);
                        foreach (var stockComponent in stockComponents)
                        {
                            if (stockComponent.Count >= countOnStocks)
                            {
                                stockComponent.Count -= countOnStocks;
                                countOnStocks = 0;
                                _context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnStocks -= stockComponent.Count;
                                stockComponent.Count = 0;
                                _context.SaveChanges();
                            }
                        }
                        if (countOnStocks > 0)
                        {
                            throw new Exception("Не достаточно компонента " +
                           productComponent.Material.MaterialName + " требуется " + productComponent.Count + ", не хватает " + countOnStocks);
                        }
                    }
                    element.DateImplement = DateTime.Now;
                    element.Status = OrderStatus.Выполняется;
                    _context.SaveChanges();
                    
                    SendEmail(element.Customer.Mail, "Оповещение по заказам",
                        string.Format("Заказ №{0} от {1} передан в работу", element.Id, element.DateCreate.ToShortDateString()));
                    
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    if (element != null)
                    {
                        element.Status = OrderStatus.НедостаточноРусурсов;
                        _context.SaveChanges();
                        transaction.Commit();
                    }
                    throw;
                }
            }
        }
        public void FinishOrder(OrderBindingModel model)
        {
            Order element = _context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }

            element.Status = OrderStatus.Готов;
            _context.SaveChanges();
            
            SendEmail(element.Customer.Mail, "Оповещение по заказам",
                string.Format("Заказ №{0} от {1} передан на оплату", element.Id, element.DateCreate.ToShortDateString()));
        }
        public void PayOrder(OrderBindingModel model)
        {
            Order element = _context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = OrderStatus.Оплачен;
            _context.SaveChanges();
            
            SendEmail(element.Customer.Mail, "Оповещение по заказам",
                string.Format("Заказ №{0} от {1} оплачен успешно", element.Id, element.DateCreate.ToShortDateString()));
        }
        public void PutMaterialOnStock(StockMaterialBindingModel model)
        {
            StockMaterial element = _context.StockMaterials.FirstOrDefault(rec =>
                rec.StockId == model.StockId && rec.MaterialId == model.MaterialId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                _context.StockMaterials.Add(new StockMaterial
                {
                    StockId = model.StockId,
                    MaterialId = model.MaterialId,
                    Count = model.Count
                });
            }
            _context.SaveChanges();
        }

        private void SendEmail(string mailAddress, string subject, string text)
        {
            MailMessage objMailMessage = new MailMessage();
            SmtpClient objSmtpClient = null;

            try
            {
                objMailMessage.From = new MailAddress(ConfigurationManager.AppSettings["MailLogin"]);
                objMailMessage.To.Add(new MailAddress(mailAddress));
                objMailMessage.Subject = subject;
                objMailMessage.Body = text;
                objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;

                objSmtpClient = new SmtpClient("smtp.gmail.com", 587);
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.EnableSsl = true;
                objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtpClient.Credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings["MailLogin"],
                    ConfigurationManager.AppSettings["MailPassword"]);
                objSmtpClient.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMailMessage = null;
                objSmtpClient = null;
            }
        }
    }
}
