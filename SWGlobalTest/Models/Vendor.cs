using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SWGlobalTest.Enums.Enumerations;

namespace SWGlobalTest.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public ValidPhoneNumberPattern ValidPhoneNumber { get; set; }
        public string Pattern { get; set; } // Comma separated string of numbers

        public List<Offer> Offers { get; set; }
    }
}
