using SWGlobalTest.ViewModels;
using SWGlobalTest.ViewModels.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWGlobalTest.Interfaces
{
    public interface IOfferService
    {
        Task<ResultModel<string>> Add(OfferPostVM model);
        Task<ResultModel<List<OfferListVM>>> GetAll(int vendorId);
        Task<ResultModel<OfferVM>> GetDetails(int id);
        Task<ResultModel<string>> Update(int id, OfferPostVM model);
    }
}
