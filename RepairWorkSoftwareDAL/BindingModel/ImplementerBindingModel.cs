using System.Runtime.Serialization;

namespace RepairWorkSoftwareDAL.BindingModel
{
    [DataContract]
    public class ImplementerBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public string Fio { get; set; }
    }
}