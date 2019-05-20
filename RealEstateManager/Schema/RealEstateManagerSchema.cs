using GraphQL;
using RealEstateManager.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateManager.Schema
{
    public class RealEstateManagerSchema : GraphQL.Types.Schema
    {
        public RealEstateManagerSchema(IDependencyResolver resolver)
            :base(resolver)
        {
            Query = resolver.Resolve<PropertyQuery>();
        }
    }
}
