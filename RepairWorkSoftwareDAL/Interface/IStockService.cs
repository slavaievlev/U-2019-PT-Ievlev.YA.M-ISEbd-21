using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.Interface
{
    public interface IStockService
    {
        List<StockViewModel> GetList();

        StockViewModel GetElement(int id);

        void AddElement(StockBindingModel model);

        void UpdElement(StockBindingModel model);

        void DelElement(int id);
    }
}
