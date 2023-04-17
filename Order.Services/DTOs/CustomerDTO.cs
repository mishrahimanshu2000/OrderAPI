using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string TaxIdentifier { get; set; }
    }
}
