using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace RepairWorkSoftwareWeb.Controllers
{
    public class OrderRestController : ApiController
    {
        [Dependency]
        private IUnityContainer container { get; set; }

        private readonly IMainService orderService;

        public OrderRestController()
        {
            var orderService = container.Resolve<IMainService>();
        }

        public OrderRestController(IMainService orderService)
        {
            this.orderService = orderService;
        }

        public HttpResponseMessage Post(OrderViewModel model)
        {
            

            var response = Request.CreateResponse<OrderViewModel>(System.Net.HttpStatusCode.Created, model);
            return response;
        }
    }
}
