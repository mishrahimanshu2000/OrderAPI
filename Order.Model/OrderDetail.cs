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
        //public int OrderID { get; set; }
        public Orders Orders { get; set; }
        [ForeignKey("OrderId")]


        [DisplayName(nameof(Product))]
        //public int ProductID { get; set; }
        public Product Product { get; set; }
        [ForeignKey("ProductId")]


        [Required]
        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? LastUpdate { get; set; } = null;
    }
}
