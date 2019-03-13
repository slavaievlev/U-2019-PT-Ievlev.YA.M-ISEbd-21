using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.ViewModel
{
    public class StockMaterialViewModel
    {
        public int Id { get; set; }

        public int StockId { get; set; }

        public int MaterialId { get; set; }

        [DisplayName("Название материала")]
        public string MaterialName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
