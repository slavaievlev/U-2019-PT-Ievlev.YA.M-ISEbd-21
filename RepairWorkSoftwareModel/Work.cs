using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareModel
{
    public class Work
    {
        public int Id { get; set; }

        public string WorkName { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("WorkId")]
        public virtual List<MaterialWork> WorkMaterials { get; set; }

        [ForeignKey("WorkId")]
        public virtual List<Order> Orders { get; set; }
    }
}
