using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWGlobalTest.Interfaces;
using SWGlobalTest.ViewModels.Offer;
using SWGlobalTest.ViewModels.Vendor;

namespace SWGlobalTest.Pages
{
    public class VendorOffersModel : PageModel
    {
        private readonly IOfferService _offerService;

        private readonly IVendorService _vendorService;


        public VendorOffersModel(IOfferService offerService, IVendorService vendorService)
        {
            _offerService = offerService;
            _vendorService = vendorService;
        }

        public List<OfferListVM> Offers { get; set; }
        public VendorVM Vendor { get; set; }

        public int VendorId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? vendorId)
        {
            if (vendorId == null)
            {
                return NotFound();
            }

            VendorId = vendorId.GetValueOrDefault();
            Vendor = (await _vendorService.GetVendorDetails(VendorId)).Data;

            if (Vendor == null)
            {
                return NotFound();
            }

            Offers = (await _offerService.GetAll(VendorId)).Data;

            return Page();
        }
    }
}
