using Microsoft.EntityFrameworkCore;
using SWGlobalTest.Interfaces;
using SWGlobalTest.Models;
using SWGlobalTest.ViewModels;
using SWGlobalTest.ViewModels.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWGlobalTest.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly SWGlobalTest.Data.ApplicationDbContext _context;

        public TransactionService(SWGlobalTest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultModel<string>> Add(TransactionPostVM model)
        {
            var result = new ResultModel<string>();



            var transaction = new Transaction()
            {
                AppUserId = model.AppUserId,
                DateCreated = DateTime.Now,
                NumberOfUnit = model.NumberOfUnit,
                OfferId = model.OfferId,
                UnitPrice = model.UnitPrice,
            };

            try
            {
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();

                result.Data = "Saved Successfully";
                return result;
            }
            catch (Exception ex)
            {
                result.AddError("Error! " + ex.Message);
                return result;
            }
        }

        public async Task<ResultModel<List<TransactionListVM>>> GetAll()
        {
            var result = new ResultModel<List<TransactionListVM>>();
            result.Data = await _context.Transactions.Select(m => new TransactionListVM()
            {
                Id = m.Id,
                NumberOfUnit = m.NumberOfUnit,
                OfferId = m.OfferId,
                OfferName = m.Offer.Name,
                UnitPrice = m.UnitPrice,
                UserName = m.AppUser.FullName,
            }).ToListAsync();

            return result;
        }

        public async Task<ResultModel<TransactionVM>> GetDetails(int id)
        {
            var result = new ResultModel<TransactionVM>();
            result.Data = await _context.Transactions.Where(n => n.Id == id).Select(m => new TransactionVM()
            {
                DateCreated = m.DateCreated,
                AppUserId = m.AppUserId,
                Id= m.Id,
                NumberOfUnit = m.NumberOfUnit,
                OfferId = m.OfferId,
                OfferName = m.Offer.Name,
                UnitPrice = m.UnitPrice,
                UserName = m.AppUser.FullName,
                VendorId = m.Offer.VendorId,
                VendorName = m.Offer.Vendor.Name
            }).FirstOrDefaultAsync();

            return result;
        }

    }
}
