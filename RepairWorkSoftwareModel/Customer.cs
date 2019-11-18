using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairWorkSoftwareModel
{
    public class Customer
    {
        public int Id { get; set; }

        public string CustomerFIO { get; set; }
        
        public string Mail { get; set; }

        [ForeignKey("CustomerId")]
        public virtual List<Order> Orders { get; set; }
        
        [ForeignKey("CustomerId")]
        public virtual List<MessageInfo> MessageInfos { get; set; }
    }
}
