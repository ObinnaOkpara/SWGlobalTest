using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SWGlobalTest.ViewModels.Transaction
{
    public class TransactionPostVM
    {
        public string AppUserId { get; set; }
        public int OfferId { get; set; }
        public int NumberOfUnit { get; set; }
        public int UnitPrice { get; set; }

        [Display(Name = "Target Phone Number")]
        [Phone]
        public string TargetPhoneNumber { get; set; }

        public int TotalCost { get { return NumberOfUnit * UnitPrice; } }

        public string OfferName { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public bool CanBuyMoreThanOneUnit { get; set; }

    }
}
