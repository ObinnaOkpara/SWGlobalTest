using SWGlobalTest.ViewModels;
using SWGlobalTest.ViewModels.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWGlobalTest.Interfaces
{
    public interface IVendorService
    {
        Task<ResultModel<string>> AddVendor(VendorPostVM model);
        Task<ResultModel<List<VendorListVM>>> GetAllVendors();
        Task<ResultModel<VendorVM>> GetVendorDetails(int id);
        Task<ResultModel<string>> UpdateVendor(int id, VendorPostVM model);
    }
}
