using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.Interface
{
    public interface IMaterialService
    {
        List<MaterialViewModel> GetList();

        MaterialViewModel GetElement(int id);

        void AddElement(MaterialBindingModel model);

        void UpdElement(MaterialBindingModel model);

        void DelElement(int id);
    }
}
