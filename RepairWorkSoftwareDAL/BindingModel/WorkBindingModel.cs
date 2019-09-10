using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.BindingModel
{
    [DataContract]
    public class WorkBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string WorkName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public List<WorkMaterialBindingModel> WorkMaterials { get; set; }
    }
}
