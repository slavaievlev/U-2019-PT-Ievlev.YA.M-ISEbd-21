using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.BindingModel
{
    [DataContract]
    public class WorkMaterialBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int MaterialId { get; set; }

        [DataMember]
        public int WorkId { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}
