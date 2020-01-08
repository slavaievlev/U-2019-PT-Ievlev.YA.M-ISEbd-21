using System.Collections.Generic;
using RepairWorkSoftwareDAL.Attribute;
using RepairWorkSoftwareDAL.BindingModel;
using RepairWorkSoftwareDAL.ViewModel;

namespace RepairWorkSoftwareDAL.Interface
{
    [CustomInterface("Интерфейс для работы с заказами на ремонтные работы")]
    public interface IMainService
    {
        [CustomMethod("Метод получения всех заказов")]
        List<OrderViewModel> GetList();

        [CustomMethod("Метод получения заказа, который готов в обработке исполнителем")]
        List<OrderViewModel> GetFreeOrders();

        [CustomMethod("Метод создания заказа")]
        void CreateOrder(OrderBindingModel model);

        [CustomMethod("Метод передачи заказа в статус \"в работе\"")]
        void TakeOrderInWork(OrderBindingModel model);

        [CustomMethod("Метод передачи заказа в статус \"готов к оплате\"")]
        void FinishOrder(OrderBindingModel model);

        [CustomMethod("Метод передачи заказа в статус \"оплачен\"")]
        void PayOrder(OrderBindingModel model);

        [CustomMethod("Метод добавления материалов на склад")]
        void PutMaterialOnStock(StockMaterialBindingModel model);
    }
}
