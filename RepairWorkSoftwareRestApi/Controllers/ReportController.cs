﻿using System;
using System.Web.Http;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;

namespace RepairWorkSoftwareRestAPI.Controllers
{
    public class ReportController : ApiController
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetStocksLoad()
        {
            var list = _service.GetStocksLoad();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }

            return Ok(list);
        }

        [HttpPost]
        public IHttpActionResult GetCustomerOrders(ReportBindingModel model)
        {
            var list = _service.GetClientOrders(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            
            return Ok(list);
        }

        [HttpPost]
        public void SaveProductPrice(ReportBindingModel model)
        {
            _service.SaveProductPrice(model);
        }
        
        [HttpPost]
        public void SaveStocksLoad(ReportBindingModel model)
        {
            _service.SaveStocksLoad(model);
        }
        
        [HttpPost]
        public void SaveCustomerOrders(ReportBindingModel model)
        {
            _service.SaveCustomerOrders(model);
        }
    }
}