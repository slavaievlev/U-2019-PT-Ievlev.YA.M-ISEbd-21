using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.ViewModel
{
    public class MaterialWorkViewModel
    {
        public int Id { get; set; }

        public int WorkId { get; set; }

        public int MaterialId { get; set; }

        [DisplayName("Компонент")]
        public string MaterialName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
