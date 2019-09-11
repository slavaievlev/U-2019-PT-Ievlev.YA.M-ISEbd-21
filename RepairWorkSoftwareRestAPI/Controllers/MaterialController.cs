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
    public class MaterialController : ApiController
    {
        private readonly IMaterialService materialService;

        public MaterialController(IMaterialService materialService)
        {
            this.materialService = materialService;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = materialService.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = materialService.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

        [HttpPost]
        public void AddElement(MaterialBindingModel model)
        {
            materialService.AddElement(model);
        }

        [HttpPost]
        public void UpdElement(MaterialBindingModel model)
        {
            materialService.UpdElement(model);
        }

        [HttpPost]
        public void DelElement(MaterialBindingModel model)
        {
            materialService.DelElement(model.Id);
        }
    }
}
