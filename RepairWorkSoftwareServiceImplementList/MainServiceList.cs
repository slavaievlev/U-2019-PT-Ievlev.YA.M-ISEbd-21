﻿using RepairWorkSoftwareDAL.BindingModel;
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
            int maxId = 0;
            for (int i = 0; i < source.Orders.Count; i++)
            {
                if (source.Orders[i].Id > maxId)
                {
                    maxId = source.Orders[i].Id;
                }
            }

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
            int index = -1;
            for (int i = 0; i < source.Orders.Count; i++) {
                if (source.Orders[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }

            if (source.Orders[index].Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }

            source.Orders[index].Status = OrderStatus.Готов;
        }

        public List<OrderViewModel> GetList()
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            for (int i = 0; i < source.Orders.Count; i++)
            {
                string customerFIO = string.Empty;
                for (int j = 0; j < source.Customers.Count; j++)
                {
                    if (source.Customers[j].Id == source.Orders[i].CustomerId)
                    {
                        customerFIO = source.Customers[j].CustomerFIO;
                        break;
                    }
                }

                string workName = string.Empty;
                for (int j = 0; j < source.Works.Count; j++)
                {
                    if (source.Works[j].Id == source.Orders[i].WorkId)
                    {
                        workName = source.Works[j].WorkName;
                        break;
                    }
                }
                result.Add(new OrderViewModel
                {
                    Id = Convert.ToString(source.Orders[i].Id),
                    CustomerId = Convert.ToString(source.Orders[i].CustomerId),
                    CustomerFIO = customerFIO,
                    WorkId = Convert.ToString(source.Orders[i].WorkId),
                    WorkName = workName,
                    Count = Convert.ToString(source.Orders[i].Count),
                    Sum = Convert.ToString(source.Orders[i].Sum),
                    DateCreate = source.Orders[i].DateCreate.ToLongDateString(),
                    DateImplement = source.Orders[i].DateImplement?.ToLongDateString(),
                    Status = source.Orders[i].Status.ToString()
                });
            }
            return result;
        }

        public void PayOrder(OrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; i++)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }

            if (source.Orders[index].Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }

            source.Orders[index].Status = OrderStatus.Оплачен;
        }

        public void TakeOrderInWork(OrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; i++)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }

            if (source.Orders[index].Status != OrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }

            source.Orders[index].DateImplement = DateTime.Now;
            source.Orders[index].Status = OrderStatus.Выполняется;
        }
    }
}
