using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }


        [Required]
        [StringLength(maximumLength:20, ErrorMessage = "Customer name is too long")]
        public string CustomerName { get; set;}


        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Adderess is Too long")]
        public string CustomerAddress { get; set;}

        [Required]
        [StringLength(20)]
        public string TaxIdentifier { get; set;}

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? LastUpdate { get; set; } = null;
    }
}
