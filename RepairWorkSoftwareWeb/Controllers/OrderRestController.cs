using RepairWorkSoftwareDAL.BindingModel;
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
        private IMainService orderService;

        public OrderRestController(IMainService orderService)
        {
            this.orderService = orderService;
        }

        public HttpResponseMessage Post(OrderViewModel model)
        {
            HttpResponseMessage response;

            if (string.IsNullOrEmpty(model.CustomerId))
            {
                response = Request.CreateResponse<OrderViewModel>(System.Net.HttpStatusCode.Forbidden, model);  // TODO
                return response;
            }

            if (string.IsNullOrEmpty(model.WorkId))
            {
                response = Request.CreateResponse<OrderViewModel>(System.Net.HttpStatusCode.Forbidden, model);  // TODO
                return response;
            }

            if (string.IsNullOrEmpty(model.Count))
            {
                response = Request.CreateResponse<OrderViewModel>(System.Net.HttpStatusCode.Forbidden, model);  // TODO
                return response;
            }

            if (string.IsNullOrEmpty(model.Sum))
            {
                response = Request.CreateResponse<OrderViewModel>(System.Net.HttpStatusCode.Forbidden, model);  // TODO
                return response;
            }

            try
            {
                orderService.CreateOrder(new OrderBindingModel
                {
                    CustomerId = Convert.ToInt32(model.CustomerId),
                    WorkId = Convert.ToInt32(model.WorkId),
                    Count = Convert.ToInt32(model.Count),
                    Sum = Convert.ToInt32(model.Sum)
                });
            }
            catch (Exception ex)
            {
                // TODO
            }

            response = Request.CreateResponse<OrderViewModel>(System.Net.HttpStatusCode.Created, model);
            return response;
        }
    }
}
