using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHub.Core.CustomValidation
{
    public class AtLeastOneLowercaseAttribute : RegularExpressionAttribute
    {
        public AtLeastOneLowercaseAttribute() : base("^.*[a-z]+.*$") { }
    }
}
