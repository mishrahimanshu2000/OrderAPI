using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Model
{
    public class ProductOrderDetail
    {
        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        public int OrderDetailId { get; set; }

        public OrderDetail OrderDetail { get; set; } = null!;
    }
}
