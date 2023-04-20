using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [StringLength(20)]
        [Required]
        public string ProductCode { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string? ProductDescription { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public virtual ICollection<ProductOrderDetail> ProductOrderDetail { get; set; } = new List<ProductOrderDetail>();

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? LastUpdate { get; set; } = null;
    }
}
