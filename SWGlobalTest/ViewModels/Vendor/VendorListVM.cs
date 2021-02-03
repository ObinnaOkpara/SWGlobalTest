using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWGlobalTest.ViewModels.Vendor
{
    public class VendorListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
    }
}
