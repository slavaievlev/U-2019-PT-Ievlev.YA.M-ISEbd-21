using System;
using System.Web.Http;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;

namespace RepairWorkSoftwareRestAPI.Controllers
{
    public class WorkController : ApiController
    {
        private readonly IWorkService _service;

        public WorkController(IWorkService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }

            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }

            return Ok(element);
        }

        [HttpPost]
        public void AddElement(WorkBindingModel model)
        {
            _service.AddElement(model);
        }

        [HttpPost]
        public void UpdElement(WorkBindingModel model)
        {
            _service.UpdElement(model);
        }

        [HttpPost]
        public void DelElement(WorkBindingModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}