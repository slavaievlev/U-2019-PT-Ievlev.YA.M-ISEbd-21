using System.Collections.Generic;
using RepairWorkSoftwareDAL.Attribute;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareDAL.Interface
{
    [CustomInterface("Интерфейс для работы с экспортом файлов")]
    public interface IReportService
    {
        [CustomMethod("Метод для вывода прайса по работам .docx")]
        void SaveWorkPrice(ReportBindingModel model);

        [CustomMethod("Метод для получения информации о загруженности складов")]
        List<StocksLoadViewModel> GetStocksLoad();

        [CustomMethod("Метод для вывода информации о загруженности складов в .xlsx")]
        void SaveStocksLoad(ReportBindingModel model);

        [CustomMethod("Метод для получения информации по заказам")]
        List<CustomerOrdersViewModel> GetCustomerOrders(ReportBindingModel model);

        [CustomMethod("Метод для вывода информации по заказам в .pdf")]
        void SaveCustomerOrders(ReportBindingModel model);
    }
}
