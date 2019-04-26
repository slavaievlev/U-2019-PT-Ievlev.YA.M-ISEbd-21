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
            List<CustomerViewModel> customerViewModels = customerService.GetList();
            return Json(customerViewModels, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetWorks()
        {
            List<WorkViewModel> workViewModels = workService.GetList();
            return Json(workViewModels, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProgressOrder(string orderid)
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            int id = Convert.ToInt32(orderid);
            try
            {
                orderService.TakeOrderInWork(new OrderBindingModel
                {
                    Id = id
                });
            }
            catch (Exception ex)
            {
                // TODO
            }
            return Json(orderViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsReadyOrder(string orderid)
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            int id = Convert.ToInt32(orderid);
            try
            {
                orderService.FinishOrder(new OrderBindingModel
                {
                    Id = id
                });
            }
            catch (Exception ex)
            {
                // TODO
            }
            return Json(orderViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PayOrder(string orderid)
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            int id = Convert.ToInt32(orderid);
            try
            {
                orderService.PayOrder(new OrderBindingModel
                {
                    Id = id
                });
            }
            catch (Exception ex)
            {
                // TODO
            }
            return Json(orderViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}