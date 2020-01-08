using System.Collections.Generic;
using RepairWorkSoftwareDAL.Attribute;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareDAL.Interface
{
    [CustomInterface("Интерфейс для работы с клиентами")]
    public interface ICustomerService
    {
        [CustomMethod("Метод получения списка клиентов")]
        List<CustomerViewModel> GetList();

        [CustomMethod("Метод получения клиента по id")]
        CustomerViewModel GetElement(int id);

        [CustomMethod("Метод добавления клиента")]
        void AddElement(CustomerBindingModel model);

        [CustomMethod("Метод изменения данных по клиенту")]
        void UpdElement(CustomerBindingModel model);

        [CustomMethod("Метод удаления клиента")]
        void DelElement(int id);
    }
}
