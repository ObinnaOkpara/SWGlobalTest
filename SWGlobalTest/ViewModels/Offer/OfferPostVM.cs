using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWGlobalTest.ViewModels.Offer
{
    public class OfferPostVM
    {
        public int VendorId { get; set; }
        [Display(Name = "Unit Price")]
        public int UnitPrice { get; set; }
        [Display(Name = "Can Buy More Than One Unit")]
        public bool CanBuyMoreThanOneUnit { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
