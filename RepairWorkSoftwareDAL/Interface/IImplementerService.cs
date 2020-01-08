using System.Collections.Generic;
using RepairWorkSoftwareDAL.Attribute;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareDAL.Interface
{
    [CustomInterface("Интерфейс для работы с исполнителями")]
    public interface IImplementerService
    {
        [CustomMethod("Метод получения всех исполнителей")]
        List<ImplementerViewModel> GetList();

        [CustomMethod("Метод получения исполнителя по id")]
        ImplementerViewModel GetElement(int id);

        [CustomMethod("Метод добавления исполнителя")]
        void AddElement(ImplementerBindingModel model);
        
        [CustomMethod("Метод обновления данных по клиенту")]
        void UpdElement(ImplementerBindingModel model);

        [CustomMethod("Метод удаления клиента по id")]
        void DelElement(int id);

        [CustomMethod("Метод получения свободного исполнителя")]
        ImplementerViewModel GetFreeWorker();
    }
}