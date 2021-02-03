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
using SWGlobalTest.ViewModels.Offer;

namespace SWGlobalTest.Pages.Offers
{
    public class EditModel : PageModel
    {
        private readonly IOfferService _offerService;

        public EditModel(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [BindProperty]
        public OfferPostVM Offer { get; set; }

        public string Errors { get; set; }
        public int Id { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Id = id.GetValueOrDefault();

            var result = await _offerService.GetDetails(Id);

            if (result.HasError)
            {
                return NotFound();
            }

            Offer = new OfferPostVM()
            {
                CanBuyMoreThanOneUnit = result.Data.CanBuyMoreThanOneUnit,
                Description = result.Data.Description,
                Name = result.Data.Name,
                UnitPrice = result.Data.UnitPrice,
                VendorId = result.Data.VendorId,
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

            var result = await _offerService.Update(Id, Offer);

            if (result.HasError)
            {
                Errors = string.Join(" /n ", result.ErrorMessages);
                return Page();
            }

            return RedirectToPage("./Index", new { vendorId = Offer.VendorId });
        }

    }
}
