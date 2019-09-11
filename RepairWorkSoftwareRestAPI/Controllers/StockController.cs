using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RepairWorkSoftwareRestAPI.Controllers
{
    public class StockController : ApiController
    {
        private readonly IStockService stockService;

        public StockController(IStockService stockService)
        {
            this.stockService = stockService;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = stockService.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = stockService.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

        [HttpPost]
        public void AddElement(StockBindingModel model)
        {
            stockService.AddElement(model);
        }

        [HttpPost]
        public void UpdElement(StockBindingModel model)
        {
            stockService.UpdElement(model);
        }

        [HttpPost]
        public void DelElement(StockBindingModel model)
        {
            stockService.DelElement(model.Id);
        }
    }
}
