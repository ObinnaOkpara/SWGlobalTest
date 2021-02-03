using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWGlobalTest.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int UnitPrice { get; set; }
        public bool CanBuyMoreThanOneUnit { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public Vendor Vendor { get; set; }
    }
}
