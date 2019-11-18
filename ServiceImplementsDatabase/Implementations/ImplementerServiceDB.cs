using System;
using System.Collections.Generic;
using System.Linq;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using RepairWorkSoftwareModel;

namespace ServiceImplementsDatabase.Implementations
{
    public class ImplementerServiceDB : IImplementerService
    {
        private readonly AbstractDbContext _context;

        public ImplementerServiceDB(AbstractDbContext context)
        {
            _context = context;
        }

        public List<ImplementerViewModel> GetList()
        {
            List<ImplementerViewModel> result = _context.Implementers
                .Select(rec => new ImplementerViewModel
                {
                    Id = rec.Id,
                    Fio = rec.Fio
                })
                .ToList();
            return result;
        }

        public ImplementerViewModel GetElement(int id)
        {
            Implementer element = _context.Implementers.FirstOrDefault(rec => rec.Id == id);

            if (element != null)
            {
                return new ImplementerViewModel
                {
                    Id = element.Id,
                    Fio = element.Fio
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(ImplementerBindingModel model)
        {
            Implementer element = _context.Implementers.FirstOrDefault(rec => rec.Fio == model.Fio);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }

            _context.Implementers.Add(new Implementer
            {
                Fio = model.Fio
            });
            _context.SaveChanges();
        }

        public void UpdElement(ImplementerBindingModel model)
        {
            Implementer element = _context.Implementers.FirstOrDefault(rec => rec.Fio == model.Fio && rec.Id == model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }

            element = _context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.Fio = model.Fio;
            _context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Implementer element = _context.Implementers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                _context.Implementers.Remove(element);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public ImplementerViewModel GetFreeWorker()
        {
            var ordersWorker = _context.Implementers
                .Select(x => new 
                {
                    ImplId = x.Id,
                    Count = x.Orders.Count(o => o.Status == OrderStatus.Выполняется)
                })
                .OrderBy(x => x.Count)
                .FirstOrDefault();
            if (ordersWorker != null)
            {
                return GetElement(ordersWorker.ImplId);
            }

            return null;
        }
    }
}