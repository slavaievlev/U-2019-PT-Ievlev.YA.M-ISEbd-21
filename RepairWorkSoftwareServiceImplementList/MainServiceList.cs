using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using RepairWorkSoftwareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareServiceImplementList
{
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;

        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrder(OrderBindingModel model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
            source.Orders.Add(new Order
            {
                Id = maxId + 1,
                CustomerId = model.CustomerId,
                WorkId = model.WorkId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            });

        }

        public void FinishOrder(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = OrderStatus.Готов;
        }

        public List<OrderViewModel> GetList()
        {
            List<OrderViewModel> result = source.Orders
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    CustomerId = rec.CustomerId,
                    WorkId = rec.WorkId,
                    DateCreate = rec.DateCreate.ToLongDateString(),
                    DateImplement = rec.DateImplement?.ToLongDateString(),
                    Status = rec.Status.ToString(),
                    Count = rec.Count,
                    Sum = rec.Sum,
                    CustomerFIO = source.Customers.FirstOrDefault(recC => recC.Id ==
                    rec.CustomerId)?.CustomerFIO,
                    WorkName = source.Works.FirstOrDefault(recP => recP.Id ==
                rec.WorkId)?.WorkName,
                })
                .ToList();
            return result;
        }

        public void PayOrder(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = OrderStatus.Оплачен;
        }

        public void TakeOrderInWork(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            
            var workMaterials = source.WorkMaterials.Where(rec => rec.WorkId
                == element.WorkId);
            foreach (var productComponent in workMaterials)
            {
                int countOnStocks = source.StockMaterials
                    .Where(rec => rec.MaterialId ==
                productComponent.MaterialId)
                    .Sum(rec => rec.Count);
                if (countOnStocks < productComponent.Count * element.Count)
                {
                    var componentName = source.Materials.FirstOrDefault(rec => rec.Id ==
                        productComponent.MaterialId);
                    throw new Exception("Не достаточно компонента " +
                        componentName?.MaterialName + " требуется " + (productComponent.Count * element.Count) +
                        ", в наличии " + countOnStocks);
                }
            }

            foreach (var productComponent in workMaterials)
            {
                int countOnStocks = productComponent.Count * element.Count;
                var stockMaterials = source.StockMaterials.Where(rec => rec.MaterialId
                    == productComponent.MaterialId);
                foreach (var stockComponent in stockMaterials)
                {
                    if (stockComponent.Count >= countOnStocks)
                    {
                        stockComponent.Count -= countOnStocks;
                        break;
                    }
                    else
                    {
                        countOnStocks -= stockComponent.Count;
                        stockComponent.Count = 0;
                    }
                }
            }
            element.DateImplement = DateTime.Now;
            element.Status = OrderStatus.Выполняется;
        }

        public void PutMaterialOnStock(StockMaterialBindingModel model)
        {
            StockMaterial element = source.StockMaterials.FirstOrDefault(rec =>
                rec.StockId == model.StockId && rec.MaterialId == model.MaterialId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.StockMaterials.Count > 0 ?
                    source.StockMaterials.Max(rec => rec.Id) : 0;
                source.StockMaterials.Add(new StockMaterial
                {
                    Id = ++maxId,
                    StockId = model.StockId,
                    MaterialId = model.MaterialId,
                    Count = model.Count
                });
            }
        }

        public List<OrderViewModel> GetFreeOrders()
        {
            throw new NotImplementedException();
        }
    }
}
