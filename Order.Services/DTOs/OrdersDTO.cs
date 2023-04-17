using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.DTOs
{
    public class OrdersDTO
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal OrderAmount { get; set; }

        public string? Comments { get; set; }
    }
}
