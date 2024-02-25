using System.ComponentModel.DataAnnotations;

namespace TaskHub.Core.DTO
{
    public class AppUserSignIn
    {
        [Required(ErrorMessage = "{0} cannot be blank")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        public string? Password { get; set; }
    }
}
