using System.Collections.Generic;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareDAL.Interface
{
    public interface IMessageInfoService
    {
        List<MessageInfoViewModel> GetList();

        MessageInfoViewModel GetElement(int id);

        void AddElement(MessageInfoBindingModel model);
    }
}