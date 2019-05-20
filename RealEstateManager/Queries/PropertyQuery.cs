using GraphQL.Types;
using RealEstateManager.DataAccess.Repositories.Contracts;
using RealEstateManager.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateManager.Queries
{
    public class PropertyQuery : ObjectGraphType
    {
        public PropertyQuery(IPropertyRepository propertyRepository)
        {
            Field<ListGraphType<PropertyType>>(
                "properties",
                resolve: context => propertyRepository.GetAll());
        }
    }
}
