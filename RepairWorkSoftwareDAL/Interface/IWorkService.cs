using System.Collections.Generic;
using RepairWorkSoftwareDAL.Attribute;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareDAL.Interface
{
    [CustomInterface("Интерфейс для работы с ремонтными работами")]
    public interface IWorkService
    {
        [CustomMethod("Метод для получения всех работ")]
        List<WorkViewModel> GetList();

        [CustomMethod("Метод для получения работы по id")]
        WorkViewModel GetElement(int id);

        [CustomMethod("Метод для добавления новой работы")]
        void AddElement(WorkBindingModel model);

        [CustomMethod("Метод для обновления данных по работе")]
        void UpdElement(WorkBindingModel model);

        [CustomMethod("Метод для удаления работы")]
        void DelElement(int id);
    }
}
