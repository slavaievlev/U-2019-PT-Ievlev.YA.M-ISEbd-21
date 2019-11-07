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
    public class WorkMaterialViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int WorkId { get; set; }

        [DataMember]
        public int MaterialId { get; set; }

        [DataMember]
        [DisplayName("Компонент")]
        public string MaterialName { get; set; }

        [DataMember]
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
