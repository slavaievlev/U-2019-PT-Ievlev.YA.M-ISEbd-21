using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.Interface;
using RepairWorkSoftwareDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RepairWorkSoftwareWeb.Controllers
{
    public class WorkRestController : ApiController
    {
        private IWorkService workService;

        public WorkRestController(IWorkService workService)
        {
            this.workService = workService;
        }

        [HttpPut]
        [Route("api/workRest/delete/")]
        public string Delete([FromBody]WorkViewModel model)
        {
            try
            {
                workService.DelElement(model.Id);
            }
            catch (Exception ex)
            {
                // TODO
            }
            return "OK";
        }
    }
}
