using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataModels.CustomModels
{
    public class LoginModel
    {

        [Required(ErrorMessage ="EmailId Is Required")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }

    }
}
