using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWGlobalTest.ViewModels.Transaction
{
    public class TransactionListVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int OfferId { get; set; }
        public string OfferName { get; set; }
        public int NumberOfUnit { get; set; }
        public int UnitPrice { get; set; }

        public int TotalCost { get { return NumberOfUnit * UnitPrice; } }
    }
}
