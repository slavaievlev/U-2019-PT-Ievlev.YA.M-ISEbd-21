using System.Collections.Generic;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

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