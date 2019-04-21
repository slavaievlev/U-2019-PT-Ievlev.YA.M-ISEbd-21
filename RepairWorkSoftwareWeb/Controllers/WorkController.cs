using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepairWorkSoftwareWeb.Controllers
{
    public class WorkController : Controller
    {
        private readonly IWorkService workService;

        public WorkController(IWorkService workService)
        {
            this.workService = workService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditWork()
        {
            return View();
        }

        public ActionResult AddMaterial()
        {
            return View();
        }

        public ActionResult GetAllWorks()
        {
            List<WorkViewModel> workViewModels = workService.GetList();
            return Json(workViewModels, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PostWork(WorkViewModel data)
        {
            // TODO

            Console.WriteLine();
            return View();
        }
    }
}