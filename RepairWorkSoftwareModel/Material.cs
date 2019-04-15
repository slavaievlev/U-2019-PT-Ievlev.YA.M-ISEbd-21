using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareModel
{
    public class Material
    {
        public int Id { get; set; }

        public string MaterialName { get; set; }

        [ForeignKey("MaterialId")]
        public virtual List<MaterialWork> WorkMaterials { get; set; }

        [ForeignKey("MaterialId")]
        public virtual List<StockMaterial> StockMaterials { get; set; }
    }
}
