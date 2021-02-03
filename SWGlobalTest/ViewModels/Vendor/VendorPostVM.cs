using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static SWGlobalTest.Enums.Enumerations;

namespace SWGlobalTest.ViewModels.Vendor
{
    public class VendorPostVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name= "Valid Phone Number")]
        public ValidPhoneNumberPattern ValidPhoneNumber { get; set; }
        public string Pattern { get; set; } // Comma separated string of numbers

    }
}
