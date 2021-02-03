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
using SWGlobalTest.ViewModels.Offer;

namespace SWGlobalTest.Pages.Offers
{
    public class DetailsModel : PageModel
    {
        private readonly IOfferService _offerService;

        public DetailsModel(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public OfferVM Offer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Offer = (await _offerService.GetDetails(id.GetValueOrDefault())).Data;

            if (Offer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
