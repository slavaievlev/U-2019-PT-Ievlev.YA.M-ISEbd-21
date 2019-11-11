using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.Interface
{
    public interface IReportService
    {
        void SaveProductPrice(ReportBindingModel model);

        List<StocksLoadViewModel> GetStocksLoad();

        void SaveStocksLoad(ReportBindingModel model);

        List<CustomerOrdersViewModel> GetClientOrders(ReportBindingModel model);

        void SaveCustomerOrders(ReportBindingModel model);
    }
}
