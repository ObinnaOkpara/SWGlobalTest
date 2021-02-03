using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SWGlobalTest.Data;
using SWGlobalTest.Interfaces;
using SWGlobalTest.Models;
using SWGlobalTest.ViewModels.Vendor;

namespace SWGlobalTest.Pages.Vendors
{
    public class DetailsModel : PageModel
    {
        private readonly IVendorService _vendorService;

        public DetailsModel(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        public VendorVM Vendor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vendor = (await _vendorService.GetVendorDetails(id.GetValueOrDefault())).Data;

            if (Vendor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
