using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepairWorkSoftwareWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditCustomer()
        {
            return View();
        }

        public ActionResult GetAllCustomers()
        {
            List<CustomerViewModel> customerViewModels = customerService.GetList();
            return Json(customerViewModels, JsonRequestBehavior.AllowGet);
        }
    }
}