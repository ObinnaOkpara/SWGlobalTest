using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SWGlobalTest.Data;
using SWGlobalTest.Interfaces;
using SWGlobalTest.Models;
using SWGlobalTest.ViewModels.Offer;

namespace SWGlobalTest.Pages.Offers
{
    [Authorize(Roles = Constants.AdminRole)]
    public class IndexModel : PageModel
    {
        private readonly IOfferService _offerService;

        public IndexModel(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public List<OfferListVM> Offer { get;set; }
        public int VendorId { get;set; }

        public async Task<IActionResult> OnGetAsync(int? vendorId)
        {
            if (vendorId == null)
            {
                return NotFound();
            }

            VendorId = vendorId.GetValueOrDefault();
            Offer = (await _offerService.GetAll(VendorId)).Data;

            return Page();
        }
    }
}
