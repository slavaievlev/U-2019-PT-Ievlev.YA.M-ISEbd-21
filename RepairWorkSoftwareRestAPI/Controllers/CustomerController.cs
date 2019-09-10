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
    public class CustomerController : ApiController
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService service)
        {
            customerService = service;
        }
        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = customerService.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = customerService.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

        [HttpPost]
        public void AddElement(CustomerBindingModel model)
        {
            customerService.AddElement(model);
        }
        [HttpPost]
        public void UpdElement(CustomerBindingModel model)
        {
            customerService.UpdElement(model);
        }
        [HttpPost]
        public void DelElement(CustomerBindingModel model)
        {
            customerService.DelElement(model.Id);
        }
    }
}
