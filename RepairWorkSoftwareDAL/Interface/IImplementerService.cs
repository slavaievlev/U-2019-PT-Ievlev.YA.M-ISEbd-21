using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.Interface
{
    public interface IImplementerService
    {
        List<ImplementerViewModel> GetList();

        ImplementerViewModel GetElement(int id);

        void AddElement(ImplementerBindingModel model);

        void UpdElement(ImplementerBindingModel model);

        void DelElement(int id);

        ImplementerViewModel GetFreeWorker();
    }
}
