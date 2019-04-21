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
    public class OrderController : Controller
    {
        private readonly IMainService orderService;
        private readonly ICustomerService customerService;
        private readonly IWorkService workService;

        public OrderController(ICustomerService customerService, IWorkService workService, IMainService orderService)
        {
            this.customerService = customerService;
            this.workService = workService;
            this.orderService = orderService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCustomers()
        {
            List<string> customerNameList = new List<string>();
            List<CustomerViewModel> customerViewModels = customerService.GetList();

            foreach (CustomerViewModel customerViewModel in customerViewModels)
            {
                customerNameList.Add(customerViewModel.CustomerFIO);
            }

            return Json(customerNameList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetWorks()
        {
            List<string> workNameList = new List<string>();
            List<WorkViewModel> workViewModels = workService.GetList();

            foreach (WorkViewModel workViewModel in workViewModels)
            {
                workNameList.Add(workViewModel.WorkName);
            }

            return Json(workNameList, JsonRequestBehavior.AllowGet);
        }
    }
}