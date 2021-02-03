using Microsoft.EntityFrameworkCore;
using SWGlobalTest.Interfaces;
using SWGlobalTest.Models;
using SWGlobalTest.ViewModels;
using SWGlobalTest.ViewModels.Offer;
using SWGlobalTest.ViewModels.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWGlobalTest.Services
{
    public class OfferService : IOfferService
    {
        private readonly SWGlobalTest.Data.ApplicationDbContext _context;

        public OfferService(SWGlobalTest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultModel<string>> Add(OfferPostVM model)
        {
            var result = new ResultModel<string>();

            //check if Offer Name already exists for vendor
            var check = await _context.Offers
                .Where(m => m.Name == model.Name.ToUpper() && m.VendorId == model.VendorId)
                .FirstOrDefaultAsync();

            if (check != null)
            {
                result.AddError("Vendor already has Offer with this name");
                return result;
            }

            var offer = new Offer()
            {
                CanBuyMoreThanOneUnit = model.CanBuyMoreThanOneUnit,
                DateCreated = DateTime.Now,
                Description = model.Description,
                Name = model.Name,
                UnitPrice = model.UnitPrice,
                VendorId = model.VendorId,
            };

            _context.Offers.Add(offer);
            await _context.SaveChangesAsync();

            result.Data = "Saved Successfully";
            return result;
        }

        public async Task<ResultModel<List<OfferListVM>>> GetAll(int vendorId)
        {
            var result = new ResultModel<List<OfferListVM>>();
            var offers = _context.Offers.AsQueryable();

            if (vendorId > 0)
            {
                offers = offers.Where(n => n.VendorId == vendorId);
            }
            result.Data = await offers.Select(m => new OfferListVM()
            {
                UnitPrice = m.UnitPrice,
                Id = m.Id,
                Name = m.Name,
                Vendor = m.Vendor.Name
            }).ToListAsync();

            return result;
        }

        public async Task<ResultModel<OfferVM>> GetDetails(int id)
        {
            var result = new ResultModel<OfferVM>();
            result.Data = await _context.Offers.Where(n => n.Id == id).Select(m => new OfferVM()
            {
                DateCreated = m.DateCreated,
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                UnitPrice = m.UnitPrice,
                Vendor = m.Vendor.Name,
                CanBuyMoreThanOneUnit = m.CanBuyMoreThanOneUnit,
                VendorId = m.VendorId
            }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<ResultModel<string>> Update(int id, OfferPostVM model)
        {
            var result = new ResultModel<string>();

            //check if Offer already exists
            var offer = await _context.Offers
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();

            if (offer == null)
            {
                result.AddError("Offer not found.");
                return result;
            }

            offer.CanBuyMoreThanOneUnit = model.CanBuyMoreThanOneUnit;
            offer.Description = model.Description;
            offer.Name = model.Name;
            offer.UnitPrice = model.UnitPrice;
            offer.VendorId = model.VendorId;

            await _context.SaveChangesAsync();

            result.Data = "Updated Successfully";
            return result;
        }
    }
}
