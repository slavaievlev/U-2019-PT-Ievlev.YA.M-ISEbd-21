using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairWorkSoftwareModel
{
    public class Implementer
    {
        public int Id { get; set; }
        
        [Required]
        public string Fio { get; set; }
        
        [ForeignKey("ImplementerId")]
        public virtual List<Order> Orders { get; set; }
    }
}