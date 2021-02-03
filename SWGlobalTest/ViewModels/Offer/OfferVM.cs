using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWGlobalTest.ViewModels.Offer
{
    public class OfferVM
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        [Display(Name = "Unit Price")]
        public int UnitPrice { get; set; }
        [Display(Name = "Can Buy More Than One Unit")]
        public bool CanBuyMoreThanOneUnit { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "DateCreated")]
        public DateTime DateCreated { get; set; }

        public string Vendor { get; set; }
    }
}
