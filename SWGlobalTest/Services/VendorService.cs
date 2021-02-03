using Microsoft.EntityFrameworkCore;
using SWGlobalTest.Interfaces;
using SWGlobalTest.Models;
using SWGlobalTest.ViewModels;
using SWGlobalTest.ViewModels.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWGlobalTest.Services
{
    public class VendorService : IVendorService
    {
        private readonly SWGlobalTest.Data.ApplicationDbContext _context;

        public VendorService(SWGlobalTest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultModel<string>> AddVendor(VendorPostVM model)
        {
            var result = new ResultModel<string>();

            //check if vendor already exists
            var check = await _context.Vendors
                .Where(m => m.Name == model.Name.ToUpper())
                .FirstOrDefaultAsync();

            if (check != null)
            {
                result.AddError("Vendor already exists with this name") ;
                return result;
            }

            var vendor = new Vendor()
            {
                ValidPhoneNumber = model.ValidPhoneNumber,
                DateCreated = DateTime.Now,
                Description = model.Description,
                Name = model.Name
            };

            if (model.ValidPhoneNumber == Enums.Enumerations.ValidPhoneNumberPattern.StartsWith)
            {
                //check pattern is valid. I.E list of comma separated numbers
                if (!CheckPatternIsValid(model.Pattern))
                {
                    result.AddError("Pattern should only contain comma separated numbers.");
                    return result;
                }

                vendor.Pattern = model.Pattern;
            }

            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();

            result.Data = "Saved Successfully";
            return result;
        }

        //check pattern is valid. I.E list of comma separated numbers
        private bool CheckPatternIsValid(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
            {
                return false;
            }

            var numberStringArray = pattern.Split(',');

            var num = 0;

            //check if every string in the array can be converted to a number
            return numberStringArray.Select(m => int.TryParse(m.Trim(), out num)).All(n=> n);
            
        }

        public async Task<ResultModel<List<VendorListVM>>> GetAllVendors()
        {
            var result = new ResultModel<List<VendorListVM>>();
            result.Data = await _context.Vendors.Select(m => new VendorListVM() {
                DateCreated = m.DateCreated,
                Id = m.Id,
                Name = m.Name
            }).ToListAsync();

            return result;
        }

        public async Task<ResultModel<VendorVM>> GetVendorDetails(int id)
        {
            var result = new ResultModel<VendorVM>();
            result.Data = await _context.Vendors.Where(n=>n.Id == id).Select(m => new VendorVM()
            {
                DateCreated = m.DateCreated,
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                Pattern = m.Pattern,
                ValidPhoneNumber = m.ValidPhoneNumber
            }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<ResultModel<string>> UpdateVendor(int id, VendorPostVM model)
        {
            var result = new ResultModel<string>();

            //check if vendor already exists
            var vendor = await _context.Vendors
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();

            if (vendor == null)
            {
                result.AddError("Vendor not found.");
                return result;
            }

            vendor.ValidPhoneNumber = model.ValidPhoneNumber;
            vendor.Description = model.Description;
            vendor.Name = model.Name;

            if (model.ValidPhoneNumber == Enums.Enumerations.ValidPhoneNumberPattern.StartsWith)
            {
                //check pattern is valid. I.E list of comma separated numbers
                if (!CheckPatternIsValid(model.Pattern))
                {
                    result.AddError("Pattern should only contain comma separated numbers.");
                    return result;
                }

                vendor.Pattern = model.Pattern;
            }

            await _context.SaveChangesAsync();

            result.Data = "Updated Successfully";
            return result;
        }
    }
}
