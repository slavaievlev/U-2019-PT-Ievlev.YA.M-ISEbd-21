using System;
using System.Collections.Generic;
using System.Linq;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using RepairWorkSoftwareModel;

namespace ServiceImplementsDatabase.Implementations
{
    public class CustomerServiceDB : ICustomerService
    {
        private readonly AbstractDbContext _context;

        public CustomerServiceDB(AbstractDbContext context)
        {
            this._context = context;
        }
        public List<CustomerViewModel> GetList()
        {
            List<CustomerViewModel> result = _context.Customers.Select(rec => new CustomerViewModel
            {
                Id = rec.Id,
                CustomerFIO = rec.CustomerFIO,
                Mail = rec.Mail
            })
            .ToList();
            return result;
        }
        public CustomerViewModel GetElement(int id)
        {
            Customer element = _context.Customers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                List<MessageInfoViewModel> messages = _context.MessageInfos.Where(r => r.CustomerId == element.Id)
                    .Select(m => new MessageInfoViewModel
                    {
                        MessageId = m.MessageId,
                        CustomerName = m.Customer.CustomerFIO,
                        DateDelivery = m.DateDelivery,
                        Subject = m.Subject,
                        Body = m.Body
                    }).ToList();
                
                return new CustomerViewModel
                {
                    Id = element.Id,
                    CustomerFIO = element.CustomerFIO,
                    Mail = element.Mail,
                    Messages = messages
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(CustomerBindingModel model)
        {
            Customer element = _context.Customers.FirstOrDefault(rec => rec.CustomerFIO == model.CustomerFIO);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            _context.Customers.Add(new Customer
            {
                CustomerFIO = model.CustomerFIO,
                Mail = model.Mail
            });
            _context.SaveChanges();
        }
        public void UpdElement(CustomerBindingModel model)
        {
            Customer element = _context.Customers.FirstOrDefault(rec => rec.CustomerFIO == model.CustomerFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = _context.Customers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.CustomerFIO = model.CustomerFIO;
            element.Mail = model.Mail;
            _context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Customer element = _context.Customers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                _context.Customers.Remove(element);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
