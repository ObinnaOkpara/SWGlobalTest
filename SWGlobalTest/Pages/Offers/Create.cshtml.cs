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
using SWGlobalTest.ViewModels.Offer;

namespace SWGlobalTest.Pages.Offers
{
    public class CreateModel : PageModel
    {
        private readonly IOfferService _offerService;

        public CreateModel(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public IActionResult OnGet(int? vendorId)
        {
            if (vendorId == null)
            {
                return NotFound();
            }

            Offer.VendorId = vendorId.GetValueOrDefault();

            return Page();
        }

        [BindProperty]
        public OfferPostVM Offer { get; set; } = new OfferPostVM();

        public string Errors { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _offerService.Add(Offer);

            if (result.HasError)
            {
                Errors = string.Join(" /n ", result.ErrorMessages);
                return Page();
            }

            return RedirectToPage("./Index", new { vendorId = Offer.VendorId});
        }
    }
}
