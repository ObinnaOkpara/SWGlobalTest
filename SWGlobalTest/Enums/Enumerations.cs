using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWGlobalTest.Enums
{
    public class Enumerations
    {
        public enum ValidPhoneNumberPattern { All,
            [Display(Name = "Starts With *")] StartsWith
        }
    }
}
