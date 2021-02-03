using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWGlobalTest.Interfaces;
using SWGlobalTest.Models;
using SWGlobalTest.ViewModels.Offer;
using SWGlobalTest.ViewModels.Transaction;

namespace SWGlobalTest.Pages
{
    [Authorize]
    public class BuyNowModel : PageModel
    {
        private readonly IOfferService _offerService;
        private readonly ITransactionService _transactionService;
        private readonly UserManager<AppUser> _userManager;

        public BuyNowModel(IOfferService offerService,
            ITransactionService transactionService,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _offerService = offerService;
            _transactionService = transactionService;
        }

        [BindProperty]
        public TransactionPostVM Transaction { get; set; } = new TransactionPostVM();

        public OfferVM Offer { get; set; }
        public string Errors { get; set; }


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

            var curUser = await _userManager.GetUserAsync(User);

            Transaction.AppUserId = curUser.Id;
            Transaction.OfferId = Offer.Id;
            Transaction.UnitPrice = Offer.UnitPrice;
            Transaction.OfferName = Offer.Name;
            Transaction.VendorId = Offer.VendorId;
            Transaction.VendorName = Offer.Vendor;
            Transaction.CanBuyMoreThanOneUnit = Offer.CanBuyMoreThanOneUnit;
            Transaction.TargetPhoneNumber = curUser.PhoneNumber;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _transactionService.Add(Transaction);

            if (result.HasError)
            {
                Errors = string.Join(" /n ", result.ErrorMessages);
                return Page();
            }

            return RedirectToPage("./Success");
        }
    }
}
