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

        public ActionResult Orders()
        {
            List<OrderViewModel> orderViewModels = service.GetList();
            orderViewModels.Add(new OrderViewModel
            {
                CustomerFIO = "Тестовое имя",
                WorkName = "Тестовое название",
                Count = 5,
                Sum = 200,
                Status = "Тестовый статус",
                DateCreate = "05.03.2019",
                DateImplement = "04.02.2018"
            });
            return Json(orderViewModels, JsonRequestBehavior.AllowGet);
        }
    }
}