using RepairWorkSoftwareDAL.BindingModel;
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

        public ActionResult GetWork(string workid)
        {
            WorkViewModel workViewModel = workService.GetElement(Convert.ToInt32(workid));
            return Json(workViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(WorkViewModel model)
        {
            if (string.IsNullOrEmpty(model.WorkName))
            {
                ViewBag.Message = "Название услуги не указано";
                return View();
            }

            if (string.IsNullOrEmpty(model.Price))
            {
                ViewBag.Message = "Цена услуги не указана";
                return View();
            }

            if (model.WorkMaterials == null || model.WorkMaterials.Count == 0)
            {
                ViewBag.Message = "Материалы для услуги не добавлены";
                return View();
            }

            try
            {
                List<MaterialWorkBindingModel> workMaterialBM = new List<MaterialWorkBindingModel>();
                for (int i = 0; i < model.WorkMaterials.Count; i++)
                {
                    workMaterialBM.Add(new MaterialWorkBindingModel
                    {
                        Id = model.WorkMaterials[i].Id,
                        WorkId = model.WorkMaterials[i].WorkId,
                        MaterialId = model.WorkMaterials[i].MaterialId,
                        Count = model.WorkMaterials[i].Count
                    });
                }

                if (model.Id == 0)
                {
                    workService.AddElement(new WorkBindingModel
                    {
                        WorkName = model.WorkName,
                        Price = Convert.ToInt32(model.Price),
                        WorkMaterials = workMaterialBM
                    });
                }
                else
                {
                    workService.UpdElement(new WorkBindingModel
                    {
                        Id = model.Id,
                        WorkName = model.WorkName,
                        Price = Convert.ToInt32(model.Price),
                        WorkMaterials = workMaterialBM
                    });
                }
            } catch (Exception ex)
            {                
                ViewBag.Message = ex.Message;
                return View();
            }

            ViewBag.Message = "Услуга успешно добавлена!";
            return View();
        }
    }
}