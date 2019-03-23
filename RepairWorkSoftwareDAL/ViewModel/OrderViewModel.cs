using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [DisplayName("ФИО Клиента")]
        public string CustomerFIO { get; set; }

        public int WorkId { get; set; }

        [DisplayName("Услуга")]
        public string WorkName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        [DisplayName("Статус")]
        public string Status { get; set; }

        [DisplayName("Дата создания")]
        public string DateCreate { get; set; }

        [DisplayName("Дата выполнения")]
        public string DateImplement { get; set; }
    }
}
