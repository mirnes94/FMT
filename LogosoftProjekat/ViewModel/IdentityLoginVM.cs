using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogosoftProjekat.ViewModel
{
    public class IdentityLoginVM
    {
         [Required(ErrorMessage = "Mandatory**")]

        [StringLength(100, ErrorMessage = "User name must contain minimum 3 characters. ", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mandatory**")]

        [StringLength(100, ErrorMessage = "Password must contain minimum 5 characters.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
