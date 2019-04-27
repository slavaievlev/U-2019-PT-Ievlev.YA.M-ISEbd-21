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
        public string Id { get; set; }

        public string CustomerId { get; set; }

        [DisplayName("ФИО Клиента")]
        public string CustomerFIO { get; set; }

        public string WorkId { get; set; }

        [DisplayName("Услуга")]
        public string WorkName { get; set; }

        [DisplayName("Количество")]
        public string Count { get; set; }

        [DisplayName("Сумма")]
        public string Sum { get; set; }

        [DisplayName("Статус")]
        public string Status { get; set; }

        [DisplayName("Дата создания")]
        public string DateCreate { get; set; }

        [DisplayName("Дата выполнения")]
        public string DateImplement { get; set; }
    }
}
