﻿using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RepairWorkSoftwareWeb.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IMainService orderService;

        public OrderController(IMainService orderService)
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
