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
                response = Request.CreateResponse<CustomerViewModel>(System.Net.HttpStatusCode.Forbidden, model);  // TODO
                return response;
            }

            customerService.AddElement(new CustomerBindingModel
            {
                CustomerFIO = model.CustomerFIO
            });

            response = Request.CreateResponse<CustomerViewModel>(System.Net.HttpStatusCode.Created, model);
            return response;
        }
    }
}
