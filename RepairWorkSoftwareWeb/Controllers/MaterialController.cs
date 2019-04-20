using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepairWorkSoftwareWeb.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialService materialService;

        public MaterialController(IMaterialService materialService)
        {
            this.materialService = materialService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditMaterial()
        {
            return View();
        }

        public ActionResult GetAllMaterials()
        {
            List<MaterialViewModel> materialViewModels = materialService.GetList();
            return Json(materialViewModels, JsonRequestBehavior.AllowGet);
        }
    }
}