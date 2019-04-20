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
    public class MaterialRestController : ApiController
    {
        private IMaterialService materialService;

        public MaterialRestController(IMaterialService materialService)
        {
            this.materialService = materialService;
        }

        public HttpResponseMessage Post(MaterialViewModel model)
        {
            HttpResponseMessage response;

            if (string.IsNullOrEmpty(model.MaterialName))
            {
                response = Request.CreateResponse<MaterialViewModel>(System.Net.HttpStatusCode.Forbidden, model);  // TODO
                return response;
            }

            materialService.AddElement(new MaterialBindingModel
            {
                MaterialName = model.MaterialName
            });

            response = Request.CreateResponse<MaterialViewModel>(System.Net.HttpStatusCode.Created, model);
            return response;
        }
    }
}
