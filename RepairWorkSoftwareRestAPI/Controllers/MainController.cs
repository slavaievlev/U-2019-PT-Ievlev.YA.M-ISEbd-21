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
    public class MainController : ApiController
    {
        private readonly IMainService mainService;

        public MainController(IMainService service)
        {
            mainService = service;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = mainService.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public void CreateOrder(OrderBindingModel model)
        {
            mainService.CreateOrder(model);
        }

        [HttpPost]
        public void TakeOrderInWork(OrderBindingModel model)
        {
            mainService.TakeOrderInWork(model);
        }

        [HttpPost]
        public void FinishOrder(OrderBindingModel model)
        {
            mainService.FinishOrder(model);
        }

        [HttpPost]
        public void PayOrder(OrderBindingModel model)
        {
            mainService.PayOrder(model);
        }

        [HttpPost]
        public void PutMaterialOnStock(StockMaterialBindingModel model)
        {
            mainService.PutMaterialOnStock(model);
        }
    }
}
