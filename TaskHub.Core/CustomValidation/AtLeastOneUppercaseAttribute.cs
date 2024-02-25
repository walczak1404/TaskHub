using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHub.Core.CustomValidation
{
    public class AtLeastOneUppercaseAttribute : RegularExpressionAttribute
    {
        public AtLeastOneUppercaseAttribute() : base("^.*[A-Z].*$") { }
    }
}
