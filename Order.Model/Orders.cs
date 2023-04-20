using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Model
{
    public class Orders
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        
        public DateTime OrderDate { get; set; } = DateTime.Today;

        [Required]
        public decimal OrderAmount { get; set; }

        public string? Comments { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? LastUpdate { get; set; } = null;

        public virtual Customer Customer { get; set; } = null!;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
