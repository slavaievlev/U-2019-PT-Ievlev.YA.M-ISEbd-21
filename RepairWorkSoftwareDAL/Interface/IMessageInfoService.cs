using System.Collections.Generic;
using RepairWorkSoftwareDAL.Attribute;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareDAL.Interface
{
    [CustomInterface("Интерфейс для работы с почтой")]
    public interface IMessageInfoService
    {
        [CustomMethod("Метод получения писем от неизвестных авторов")]
        List<MessageInfoViewModel> GetList();

        [CustomMethod("Метод получения письма по id")]
        MessageInfoViewModel GetElement(int id);

        [CustomMethod("Метод добавления письма в БД")]
        void AddElement(MessageInfoBindingModel model);
    }
}