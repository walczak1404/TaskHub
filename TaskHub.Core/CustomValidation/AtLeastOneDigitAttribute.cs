using System.ComponentModel.DataAnnotations;

namespace TaskHub.Core.CustomValidation
{
    public class AtLeastOneDigitAttribute : RegularExpressionAttribute
    {
        public AtLeastOneDigitAttribute() : base("^.*\\d+.*$") { }
    }
}
