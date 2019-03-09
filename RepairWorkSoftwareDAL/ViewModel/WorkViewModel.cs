using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.ViewModel
{
    public class WorkViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название услуга")]
        public string WorkName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public List<MaterialWorkViewModel> WorkMaterials { get; set; }
    }
}
