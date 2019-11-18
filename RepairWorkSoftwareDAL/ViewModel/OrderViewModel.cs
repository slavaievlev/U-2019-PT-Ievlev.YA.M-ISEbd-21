using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.ViewModel
{
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        [DisplayName("ФИО Клиента")]
        public string CustomerFIO { get; set; }

        [DataMember]
        public int WorkId { get; set; }

        [DataMember]
        [DisplayName("Услуга")]
        public string WorkName { get; set; }

        [DataMember]
        [DisplayName("Количество")]
        public int Count { get; set; }

        [DataMember]
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        [DataMember]
        [DisplayName("Статус")]
        public string Status { get; set; }

        [DataMember]
        [DisplayName("Дата создания")]
        public string DateCreate { get; set; }

        [DataMember]
        [DisplayName("Дата выполнения")]
        public string DateImplement { get; set; }
        
        [DataMember]
        public int? ImplementerId { get; set; }
        
        [DataMember]
        public string ImplementerName { get; set; }
    }
}
