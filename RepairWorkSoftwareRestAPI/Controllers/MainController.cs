using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using RepairWorkSoftwareRestAPI.Services;
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
        private readonly IImplementerService implementerService;

        public MainController(IMainService mainService,
            IImplementerService implementerService)
        {
            this.mainService = mainService;
            this.implementerService = implementerService;
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
        public void PayOrder(OrderBindingModel model)
        {
            mainService.PayOrder(model);
        }

        [HttpPost]
        public void StartWork()
        {
            List<OrderViewModel> orders = mainService.GetFreeOrders();
            foreach (var order in orders)
            {
                ImplementerViewModel impl = implementerService.GetFreeWorker();
                if (impl == null)
                {
                    throw new Exception("Нет сотрудников");
                }
                new WorkImplementer(mainService, implementerService, impl.Id, order.Id);
            }
        }

        [HttpPost]
        public void PutMaterialOnStock(StockMaterialBindingModel model)
        {
            mainService.PutMaterialOnStock(model);
        }
    }
}
