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
using SWGlobalTest.ViewModels.Transaction;

namespace SWGlobalTest.Pages.Transaction
{
    [Authorize(Roles = Constants.AdminRole)]
    public class IndexModel : PageModel
    {
        private readonly ITransactionService _transactionService;

        public IndexModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public List<TransactionListVM> Transaction { get;set; }

        public async Task OnGetAsync()
        {
            Transaction = (await _transactionService.GetAll()).Data;
        }
    }
}
