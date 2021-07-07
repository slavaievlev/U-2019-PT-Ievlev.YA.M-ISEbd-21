using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareModel
{
    public class MaterialWork
    {
        public int Id { get; set; }

        public int MaterialId { get; set; }

        public int WorkId { get; set; }

        public int Count { get; set; }

        public virtual Material Material { get; set; }

        public virtual Work Work { get; set; }
    }
}
