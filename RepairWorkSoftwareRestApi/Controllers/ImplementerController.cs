using System;
using System.Web.Http;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;

namespace RepairWorkSoftwareRestAPI.Controllers
{
    public class ImplementerController : ApiController
    {
        private readonly IImplementerService _service;

        public ImplementerController(IImplementerService service)
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
        public IHttpActionResult GetElement(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            
            return Ok(element);
        }

        [HttpPost]
        public void AddElement(ImplementerBindingModel model)
        {
            _service.AddElement(model);
        }

        [HttpPost]
        public void UpdElement(ImplementerBindingModel model)
        {
            _service.UpdElement(model);
        }

        [HttpPost]
        public void DelElement(ImplementerBindingModel model)
        {
            _service.DelElement(model.Id);
        }

        [HttpGet]
        public IHttpActionResult GetFreeWorker()
        {
            var element = _service.GetFreeWorker();
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }

            return Ok(element);
        }
    }
}