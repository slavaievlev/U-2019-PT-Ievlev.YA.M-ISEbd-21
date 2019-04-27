using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepairWorkSoftwareWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMainService service;

        public HomeController(IMainService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllOrders()
        {
            List<OrderViewModel> orderViewModels = service.GetList();
            return Json(orderViewModels, JsonRequestBehavior.AllowGet);
        }
    }
}