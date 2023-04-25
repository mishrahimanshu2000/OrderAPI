using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OrderAPI.Authorization.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is Required")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; } = null!;
    }
}
