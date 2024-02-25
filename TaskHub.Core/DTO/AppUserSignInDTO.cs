using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHub.Core.DTO
{
    public class AppUserSignInDTO
    {
        [Required(ErrorMessage = "{0} cannot be blank")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        public string Password { get; set; }
    }
}
