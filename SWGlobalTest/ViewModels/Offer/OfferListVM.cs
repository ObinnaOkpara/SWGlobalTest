using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWGlobalTest.ViewModels.Offer
{
    public class OfferListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Unit Price")]
        public int UnitPrice { get; set; }
        public string Vendor { get; set; }
    }
}
