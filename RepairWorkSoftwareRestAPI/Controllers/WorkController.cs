using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RepairWorkSoftwareRestAPI.Controllers
{
    public class WorkController : ApiController
    {
        private readonly IWorkService workService;

        public WorkController(IWorkService workService)
        {
            this.workService = workService;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = workService.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = workService.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

        [HttpPost]
        public void AddElement(WorkBindingModel model)
        {
            workService.AddElement(model);
        }

        [HttpPost]
        public void UpdElement(WorkBindingModel model)
        {
            workService.UpdElement(model);
        }

        [HttpPost]
        public void DelElement(WorkBindingModel model)
        {
            workService.DelElement(model.Id);
        }
    }
}
