using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using RepairWorkSoftwareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementsDatabase.Implementations
{
    public class StockServiceDB : IStockService
    {
        private AbstractDbContext context;

        public StockServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }
        public List<StockViewModel> GetList()
        {
            List<StockViewModel> result = context.Stocks.Select(rec => new StockViewModel
            {
                Id = rec.Id,
                StockName = rec.StockName,
                StockMaterials = context.StockMaterials
                    .Where(recPC => recPC.StockId == rec.Id)
                    .Select(recPC => new StockMaterialViewModel
                    {
                        Id = recPC.Id,
                        StockId = recPC.StockId,
                        MaterialId = recPC.MaterialId,
                        MaterialName = context.Materials.FirstOrDefault(recC => recC.Id == recPC.MaterialId).MaterialName,
                        Count = recPC.Count
                    })
                    .ToList()
            })
            .ToList();
            return result;
        }
        public StockViewModel GetElement(int id)
        {
            Stock element = context.Stocks.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new StockViewModel
                {
                    Id = element.Id,
                    StockName = element.StockName,
                    StockMaterials = context.StockMaterials
                        .Where(recPC => recPC.StockId == element.Id)
                       .Select(recPC => new StockMaterialViewModel
                       {
                           Id = recPC.Id,
                           StockId = recPC.StockId,
                           MaterialId = recPC.MaterialId,
                           MaterialName = context.Materials.FirstOrDefault(recC => recC.Id == recPC.MaterialId).MaterialName,
                           Count = recPC.Count
                       })
                       .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(StockBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Stock element = context.Stocks.FirstOrDefault(rec => rec.StockName == model.StockName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть склад с таким названием");
                    }
                    context.Stocks.Add(new Stock
                    {
                        StockName = model.StockName
                    });
                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void UpdElement(StockBindingModel model)
        {
            using(var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Stock element = context.Stocks.FirstOrDefault(rec => rec.StockName == model.StockName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть склад с таким названием");
                    }
                    element = context.Stocks.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.StockName = model.StockName;
                    context.SaveChanges();

                    transaction.Commit();
                } catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void DelElement(int id)
        {
            using(var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Stock element = context.Stocks.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        context.StockMaterials.RemoveRange(context.StockMaterials.Where(rec => rec.StockId == id));
                        context.Stocks.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }

                    transaction.Commit();
                } catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
