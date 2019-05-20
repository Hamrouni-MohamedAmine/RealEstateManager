using RealEstateManager.DataAccess.Repositories.Contracts;
using RealEstateManager.Database;
using RealEstateManager.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateManager.DataAccess.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly RealEstateContext _ctx;

        public PropertyRepository(RealEstateContext _ctx)
        {
            this._ctx = _ctx;
        }

        public IEnumerable<Property> GetAll()
        {
            return _ctx.Properties;
        }
    }
}
