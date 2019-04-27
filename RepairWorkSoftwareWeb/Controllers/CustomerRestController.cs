using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RepairWorkSoftwareWeb.Controllers
{
    public class CustomerRestController : ApiController
    {
        private ICustomerService customerService;

        public CustomerRestController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public HttpResponseMessage Post(CustomerViewModel model)
        {
            HttpResponseMessage response;

            if (string.IsNullOrEmpty(model.CustomerFIO))
            {
                throw new Exception("Не указано ФИО клиента");
            }

            if (model.Id == 0)
            {
                customerService.AddElement(new CustomerBindingModel
                {
                    CustomerFIO = model.CustomerFIO
                });
            } else
            {
                customerService.UpdElement(new CustomerBindingModel
                {
                    Id = model.Id,
                    CustomerFIO = model.CustomerFIO
                });
            }

            response = Request.CreateResponse<CustomerViewModel>(System.Net.HttpStatusCode.Created, model);
            return response;
        }

        [HttpPut]
        [Route("api/customerRest/delete/")]
        public string Delete([FromBody]CustomerViewModel model)
        {
            customerService.DelElement(model.Id);
            return "OK";
        }
    }
}
