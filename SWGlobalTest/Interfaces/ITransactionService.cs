using SWGlobalTest.ViewModels;
using SWGlobalTest.ViewModels.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWGlobalTest.Interfaces
{
    public interface ITransactionService
    {
        Task<ResultModel<string>> Add(TransactionPostVM model);
        Task<ResultModel<List<TransactionListVM>>> GetAll();
        Task<ResultModel<TransactionVM>> GetDetails(int id);
    }
}
