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
using SWGlobalTest.ViewModels.Vendor;

namespace SWGlobalTest.Pages.Vendors
{
    [Authorize(Roles = Constants.AdminRole)]
    public class IndexModel : PageModel
    {
        private readonly IVendorService _vendorService;

        public IndexModel(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        public List<VendorListVM> Vendor { get;set; }

        public async Task OnGetAsync()
        {
            var result = await _vendorService.GetAllVendors();

            Vendor = result.Data;
        }
    }
}
