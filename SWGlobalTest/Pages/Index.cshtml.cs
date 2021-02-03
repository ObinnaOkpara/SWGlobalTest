using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SWGlobalTest.Interfaces;
using SWGlobalTest.ViewModels.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWGlobalTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IVendorService _vendorService;

        public IndexModel(ILogger<IndexModel> logger, IVendorService vendorService)
        {
            _logger = logger;
            _vendorService = vendorService;
        }

        public List<VendorListVM> Vendors { get; set; }

        public async Task OnGetAsync()
        {
            var result = await _vendorService.GetAllVendors();

            Vendors = result.Data;
        }
    }
}
