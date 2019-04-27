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
                throw new Exception("Не указан клиент");
            }

            if (string.IsNullOrEmpty(model.WorkId))
            {
                throw new Exception("Не указана услуга");
            }

            if (string.IsNullOrEmpty(model.Count))
            {
                throw new Exception("Не указано количество услуг в заказе");
            }

            if (string.IsNullOrEmpty(model.Sum))
            {
                throw new Exception("Не подсчитана сумма заказа");
            }

            orderService.CreateOrder(new OrderBindingModel
            {
                CustomerId = Convert.ToInt32(model.CustomerId),
                WorkId = Convert.ToInt32(model.WorkId),
                Count = Convert.ToInt32(model.Count),
                Sum = Convert.ToInt32(model.Sum)
            });

            response = Request.CreateResponse<OrderViewModel>(System.Net.HttpStatusCode.Created, model);
            return response;
        }

        [HttpPut]
        [Route("api/orderRest/progressorder/")]
        public HttpResponseMessage ProgressOrder(string orderid)
        {
            HttpResponseMessage response;

            OrderViewModel orderViewModel = new OrderViewModel();
            int id = Convert.ToInt32(orderid);
            orderService.TakeOrderInWork(new OrderBindingModel
            {
                Id = id
            });

            response = Request.CreateResponse<string>(System.Net.HttpStatusCode.Created, orderid);
            return response;
        }

        [HttpPut]
        [Route("api/orderRest/isreadyorder/")]
        public HttpResponseMessage IsReadyOrder(string orderid)
        {
            HttpResponseMessage response;

            OrderViewModel orderViewModel = new OrderViewModel();
            int id = Convert.ToInt32(orderid);
            orderService.FinishOrder(new OrderBindingModel
            {
                Id = id
            });

            response = Request.CreateResponse<string>(System.Net.HttpStatusCode.Created, orderid);
            return response;
        }

        [HttpPut]
        [Route("api/orderRest/payorder/")]
        public HttpResponseMessage PayOrder(string orderid)
        {
            HttpResponseMessage response;

            OrderViewModel orderViewModel = new OrderViewModel();
            int id = Convert.ToInt32(orderid);
            orderService.PayOrder(new OrderBindingModel
            {
                Id = id
            });

            response = Request.CreateResponse<string>(System.Net.HttpStatusCode.Created, orderid);
            return response;
        }
    }
}
