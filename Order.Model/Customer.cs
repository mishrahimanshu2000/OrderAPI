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
        [StringLength(100)]
        public string CustomerName { get; set;}


        [Required]
        [StringLength(100)]
        public string CustomerAddress { get; set;}

        [Required]
        [StringLength(20)]
        public string TaxIdentifier { get; set;}
    }
}
