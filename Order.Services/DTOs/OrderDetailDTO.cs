using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.DTOs
{
    public class OrderDetailDTO
    {
        public int OrderDetailId { get; internal set; }
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }
    }
}
