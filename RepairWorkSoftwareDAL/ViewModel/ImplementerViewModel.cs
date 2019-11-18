using System.Runtime.Serialization;

namespace RepairWorkSoftwareDAL.ViewModel
{
    [DataContract]
    public class ImplementerViewModel
    {
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public string Fio { get; set; }
    }
}