using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWGlobalTest.ViewModels.Transaction
{
    public class TransactionVM
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public string UserName { get; set; }
        public int OfferId { get; set; }
        public string OfferName { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public int NumberOfUnit { get; set; }
        public int UnitPrice { get; set; }

        public int TotalCost { get { return NumberOfUnit * UnitPrice; } }

        public DateTime DateCreated { get; set; }

    }
}
