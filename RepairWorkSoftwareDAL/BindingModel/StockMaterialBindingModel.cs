using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.BindingModel
{
    public class StockMaterialBindingModel
    {
        public int Id { get; set; }

        public int StockId { get; set; }

        public int MaterialId { get; set; }

        public int Count { get; set; }
    }
}
