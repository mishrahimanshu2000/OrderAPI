using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Model.CustomAttributes
{
    public class IsValidAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var inputVal = value as string;
            return !string.IsNullOrEmpty(inputVal) || !string.IsNullOrWhiteSpace(inputVal);
        }
    }
}
