using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.Interface
{
    public interface IWorkService
    {
        List<WorkViewModel> GetList();

        WorkViewModel GetElement(int id);

        void AddElement(WorkBindingModel model);

        void UpdElement(WorkBindingModel model);

        void DelElement(int id);
    }
}
