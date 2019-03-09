using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.BindingModel
{
    public class OrderBindingModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int WorkId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}
