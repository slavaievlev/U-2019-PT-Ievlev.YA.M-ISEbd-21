using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.BindingModel
{
    public class WorkMaterialBindingModel
    {
        public int Id { get; set; }

        public int MaterialId { get; set; }

        public int WorkId { get; set; }

        public int Count { get; set; }
    }
}
