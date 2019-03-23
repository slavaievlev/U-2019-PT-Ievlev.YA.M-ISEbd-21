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
    public class StockServiceList : IStockService
    {
        private DataListSingleton source;
        public StockServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<StockViewModel> GetList()
        {
            List<StockViewModel> result = source.Stocks
            .Select(rec => new StockViewModel
            {
                Id = rec.Id,
                StockName = rec.StockName,
                StockMaterials = source.StockMaterials
                    .Where(recPC => recPC.StockId == rec.Id)
                    .Select(recPC => new StockMaterialViewModel
                    {
                        Id = recPC.Id,
                        StockId = recPC.StockId,
                        MaterialId = recPC.MaterialId,
                        MaterialName = source.Materials
                    .FirstOrDefault(recC => recC.Id ==
                        recPC.MaterialId)?.MaterialName,
                        Count = recPC.Count
                    })
                    .ToList()
            })
            .ToList();
            return result;
        }
        public StockViewModel GetElement(int id)
        {
            Stock element = source.Stocks.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new StockViewModel
                {
                    Id = element.Id,
                    StockName = element.StockName,
                    StockMaterials = source.StockMaterials
                        .Where(recPC => recPC.StockId == element.Id)
                       .Select(recPC => new StockMaterialViewModel
                       {
                           Id = recPC.Id,
                           StockId = recPC.StockId,
                           MaterialId = recPC.MaterialId,
                           MaterialName = source.Materials
                        .FirstOrDefault(recC => recC.Id ==
                            recPC.MaterialId)?.MaterialName,
                            Count = recPC.Count
                       })
                       .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(StockBindingModel model)
        {
            Stock element = source.Stocks.FirstOrDefault(rec => rec.StockName ==
           model.StockName);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            int maxId = source.Stocks.Count > 0 ? source.Stocks.Max(rec => rec.Id) : 0;
            source.Stocks.Add(new Stock
            {
                Id = maxId + 1,
                StockName = model.StockName
            });
        }
        public void UpdElement(StockBindingModel model)
        {
            Stock element = source.Stocks.FirstOrDefault(rec =>
            rec.StockName == model.StockName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = source.Stocks.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.StockName = model.StockName;
        }
        public void DelElement(int id)
        {
            Stock element = source.Stocks.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.StockMaterials.RemoveAll(rec => rec.StockId == id);
                source.Stocks.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
