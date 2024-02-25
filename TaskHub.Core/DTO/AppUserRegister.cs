using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TaskHub.Core.CustomValidation;
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
        [AtLeastOneDigit(ErrorMessage = "{0} must have at least one digit")]
        [AtLeastOneLowercase(ErrorMessage = "{0} must have at least one lowercase character")]
        [AtLeastOneUppercase(ErrorMessage = "{0} must have at least one uppercase character")]
        [AtLeastOneSpecial(ErrorMessage = "{0} must have at least one special character")]
        public string? Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords are not the same")]
        public string? PasswordConfirm { get; set; }
    }
}
