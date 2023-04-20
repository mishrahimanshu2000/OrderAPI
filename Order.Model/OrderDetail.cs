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
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? LastUpdate { get; set; } = null;

        public virtual ICollection<ProductOrderDetail> ProductOrderDetail { get; set; } = new List<ProductOrderDetail>();

        public virtual Orders Order { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
