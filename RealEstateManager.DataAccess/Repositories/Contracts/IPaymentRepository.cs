using RealEstateManager.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateManager.DataAccess.Repositories.Contracts
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAllForProperty(int propertyId);
        IEnumerable<Payment> GetAllForProperty(int propertyId, int lastAmount);
    }
}
