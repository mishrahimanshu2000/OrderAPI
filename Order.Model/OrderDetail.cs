﻿using System;
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
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public Orders Orders { get; set; }


        [DisplayName(nameof(Product))]
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }


        [Required]
        public int Quantity { get; set; }
    }
}
