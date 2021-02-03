using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SWGlobalTest.Data;
using SWGlobalTest.Interfaces;
using SWGlobalTest.Models;
using SWGlobalTest.ViewModels.Vendor;

namespace SWGlobalTest.Pages.Vendors
{
    public class EditModel : PageModel
    {
        private readonly IVendorService _vendorService;

        public EditModel(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [BindProperty]
        public VendorPostVM Vendor { get; set; }
        [BindProperty]
        public int Id { get; set; }

        public string Errors { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Id = id.GetValueOrDefault();
            var result = await _vendorService.GetVendorDetails(Id);

            if (result == null)
            {
                return NotFound();
            }

            Vendor = new VendorPostVM() { 
                Description = result.Data.Description,
                Name = result.Data.Name,
                Pattern = result.Data.Pattern,
                ValidPhoneNumber = result.Data.ValidPhoneNumber,
            };
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _vendorService.UpdateVendor(Id, Vendor);

            if (result.HasError)
            {
                Errors = string.Join(" /n ", result.ErrorMessages);
                return Page();
            }


            return RedirectToPage("./Index");
        }
    }
}
