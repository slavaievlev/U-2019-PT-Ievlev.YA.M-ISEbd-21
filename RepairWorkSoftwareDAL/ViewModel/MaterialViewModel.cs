using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.ViewModel
{
    public class MaterialViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название материала")]
        public string MaterialName { get; set; }
    }
}
