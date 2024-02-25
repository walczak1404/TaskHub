using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TaskHub.Core.CustomValidation;
using TaskHub.Core.Domain.Entities.Identity;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace TaskHub.Core.DTO
{
    public class AppUserRegister
    {
        [Required(ErrorMessage = "{0} cannot be blank")]
        [StringLength(50, ErrorMessage = "{0} cannot be longer than 50 characters")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        [EmailAddress(ErrorMessage = "{0} must be in valid email format")]
        //[Remote("test", "test")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        [StringLength(256, MinimumLength = 8, ErrorMessage = "{0} must have at least {2} characters")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).*$", ErrorMessage = "Password must have at least 1 lowercase, 1 uppercase, 1 special character and 1 digit")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords are not the same")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set; }


        public AppUser ToAppUserWithoutPassword()
        {
            return new AppUser()
            {
                UserName = Username,
                Email = Email
            };
        }
    }
}
