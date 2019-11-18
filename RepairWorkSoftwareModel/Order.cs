using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareModel
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int WorkId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Work Work { get; set; }
        
        public int? ImplementerId { get; set; }

        public virtual Implementer Implementer { get; set; }
    }
}
