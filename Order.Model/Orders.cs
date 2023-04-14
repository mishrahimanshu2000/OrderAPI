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
        [Key]
        public int OrderId { get; set; }


        [DisplayName(nameof(Customer))]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Today;


        [Required]
        public decimal OrderAmount { get; set; }

        public string? Comments { get; set; }
    }
}
