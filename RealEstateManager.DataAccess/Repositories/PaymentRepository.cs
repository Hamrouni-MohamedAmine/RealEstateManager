using RealEstateManager.DataAccess.Repositories.Contracts;
using RealEstateManager.Database;
using RealEstateManager.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateManager.DataAccess.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly RealEstateContext _dbContext;

        public PaymentRepository(RealEstateContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public IEnumerable<Payment> GetAllForProperty(int propertyId)
        {
            return _dbContext.Payments.Where(x => x.PropertyId == propertyId);
        }

        public IEnumerable<Payment> GetAllForProperty(int propertyId, int lastAmount)
        {
            return _dbContext.Payments.Where(x => x.PropertyId == propertyId)
                .OrderByDescending(x=>x.DateCreated)
                .Take(lastAmount);
        }
    }
}
