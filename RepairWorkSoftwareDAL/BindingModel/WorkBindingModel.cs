using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.BindingModel
{
    public class WorkBindingModel
    {
        public int Id { get; set; }

        public string WorkName { get; set; }

        public decimal Price { get; set; }

        public List<MaterialWorkBindingModel> WorkMaterials { get; set; }
    }
}
