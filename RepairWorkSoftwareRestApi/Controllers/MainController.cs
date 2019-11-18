﻿using System;
 using System.Collections.Generic;
 using System.Web.Http;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;
 using RepairWorkSoftwareDAL.ViewModel;
 using RepairWorkSoftwareRestApi.Service;

 namespace RepairWorkSoftwareRestAPI.Controllers
{
    public class MainController : ApiController
    {
        private readonly IMainService _mainService;

        private readonly IImplementerService _implementerService;

        public MainController(IMainService mainService,
            IImplementerService implementerService)
        {
            _mainService = mainService;
            _implementerService = implementerService;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _mainService.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }

            return Ok(list);
        }

        [HttpPost]
        public void CreateOrder(OrderBindingModel model)
        {
            _mainService.CreateOrder(model);
        }

        [HttpPost]
        public void PayOrder(OrderBindingModel model)
        {
            _mainService.PayOrder(model);
        }

        [HttpPost]
        public void PutMaterialOnStock(StockMaterialBindingModel model)
        {
            _mainService.PutMaterialOnStock(model);
        }

        [HttpPost]
        public void StartWork()
        {
            List<OrderViewModel> orders = _mainService.GetFreeOrders();
            foreach (var order in orders)
            {
                ImplementerViewModel impl = _implementerService.GetFreeWorker();
                if (impl == null)
                {
                    throw new Exception("Нет сотрудников");
                }

                new WorkImplementer(_mainService, _implementerService, impl.Id, order.Id);
            }
        }
    }
}