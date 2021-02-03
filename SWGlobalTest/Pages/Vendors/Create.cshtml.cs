using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SWGlobalTest.Data;
using SWGlobalTest.Interfaces;
using SWGlobalTest.Models;
using SWGlobalTest.ViewModels.Vendor;

namespace SWGlobalTest.Pages.Vendors
{
    public class CreateModel : PageModel
    {
        private readonly IVendorService _vendorService;

        public CreateModel(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public VendorPostVM Vendor { get; set; }

        public string Errors { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _vendorService.AddVendor(Vendor);

            if (result.HasError)
            {
                Errors = string.Join(" /n ", result.ErrorMessages);
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
