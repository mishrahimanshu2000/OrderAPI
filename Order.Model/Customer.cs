using Order.Model.CustomAttributes;
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
        [StringLength(maximumLength: 20, ErrorMessage = "Customer name is too long")]
        [IsValid(ErrorMessage = "Name should not be empty null or whiteSpace")]
        public string CustomerName { get; set; } = null!;


        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Adderess is Too long")]
        public string CustomerAddress { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string? TaxIdentifier { get; set;}

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? LastUpdate { get; set; } = null;
        
        public virtual ICollection<Orders> CustomerOrder { get; set;} = new List<Orders>();
    }

    public class ProductByCustomer
    {
        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        public int OrderDetailId { get; set; }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }

        public string ProductCode { get; set; }

        public decimal Price { get; set; }
    }

}