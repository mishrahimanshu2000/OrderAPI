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


        [DisplayName(nameof(Orders))]
        //[ForeignKey("OrderId")]
        public Orders Orders { get; set; }


        [DisplayName(nameof(Product))]
        //[ForeignKey("ProductId")]
        public Product Product { get; set; }

        //public ICollection<Product> Product { get; set; }

        public ICollection<ProductOrderDetail> ProductOrders { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? LastUpdate { get; set; } = null;
    }
}
