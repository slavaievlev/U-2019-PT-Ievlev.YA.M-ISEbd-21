using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using RepairWorkSoftwareModel;

namespace ServiceImplementsDatabase.Implementations
{
    public class MessageInfoServiceDB : IMessageInfoService
    {
        private readonly AbstractDbContext _context;

        public MessageInfoServiceDB(AbstractDbContext context)
        {
            _context = context;
        }

        public List<MessageInfoViewModel> GetList()
        {
            return _context.MessageInfos
                .Where(m => !m.CustomerId.HasValue)
                .Select(m => new MessageInfoViewModel
                {
                    MessageId = m.MessageId,
                    CustomerName = m.FromMailAddress,
                    DateDelivery = m.DateDelivery,
                    Subject = m.Subject,
                    Body = m.Body
                })
                .ToList();
        }

        public MessageInfoViewModel GetElement(int id)
        {
            MessageInfo element = _context.MessageInfos
                .Include(m => m.Customer)
                .FirstOrDefault(m => m.Id == id);
            if (element != null)
            {
                return new MessageInfoViewModel
                {
                    MessageId = element.MessageId,
                    CustomerName = element.FromMailAddress,
                    DateDelivery = element.DateDelivery,
                    Subject = element.Subject,
                    Body = element.Body
                };
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(MessageInfoBindingModel model)
        {
            MessageInfo element = _context.MessageInfos.FirstOrDefault(m => m.MessageId == model.MessageId);
            if (element != null)
            {
                return;
            }

            var message = new MessageInfo
            {
                MessageId = model.MessageId,
                FromMailAddress = model.FromMailAddress,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body
            };

            var mailAddress = Regex.Match(model.FromMailAddress,
                @"(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))
(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))");
            if (mailAddress.Success)
            {
                var customer = _context.Customers.FirstOrDefault(c => c.Mail == mailAddress.Value);
                if (customer != null)
                {
                    message.CustomerId = customer.Id;
                }
            }

            _context.MessageInfos.Add(message);
            _context.SaveChanges();
        }
    }
}