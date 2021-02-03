using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SWGlobalTest.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public int OfferId { get; set; }
        public int NumberOfUnit { get; set; }
        public int UnitPrice { get; set; }

        [NotMapped]
        public int TotalCost { get { return NumberOfUnit * UnitPrice; } }

        public DateTime DateCreated { get; set; }

        public AppUser AppUser { get; set; }
        public Offer Offer { get; set; }

        public List<Complaint> Complaints { get; set; }
    }
}
