using System.Collections.Generic;
using RepairWorkSoftwareDAL.Attribute;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareDAL.Interface
{
    [CustomInterface("Интерфейс для работы со складами")]
    public interface IStockService
    {
        [CustomMethod("Метод для получения всех складов")]
        List<StockViewModel> GetList();

        [CustomMethod("Метод для получения склада по id")]
        StockViewModel GetElement(int id);

        [CustomMethod("Метод для добавления склада")]
        void AddElement(StockBindingModel model);

        [CustomMethod("Метод для обновления данных по складу")]
        void UpdElement(StockBindingModel model);

        [CustomMethod("Метод для удаления склада")]
        void DelElement(int id);
    }
}
