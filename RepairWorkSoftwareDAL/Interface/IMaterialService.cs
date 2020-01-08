using System.Collections.Generic;
using RepairWorkSoftwareDAL.Attribute;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareDAL.Interface
{
    [CustomInterface("Интерфейс для работы с материалами")]
    public interface IMaterialService
    {
        [CustomMethod("Метод для получения всех материалов")]
        List<MaterialViewModel> GetList();

        [CustomMethod("Метод для получения материала по id")]
        MaterialViewModel GetElement(int id);

        [CustomMethod("Метод для добавления материала")]
        void AddElement(MaterialBindingModel model);

        [CustomMethod("Метод для обновления данных по материалу")]
        void UpdElement(MaterialBindingModel model);

        [CustomMethod("Метод для удаления материала")]
        void DelElement(int id);
    }
}
