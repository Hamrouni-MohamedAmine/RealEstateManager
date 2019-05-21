using GraphQL.Types;
using RealEstateManager.DataAccess.Repositories;
using RealEstateManager.DataAccess.Repositories.Contracts;
using RealEstateManager.Database.Models;
using RealEstateManager.Types.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateManager.Types
{
    public class PropertyType : ObjectGraphType<Property>
    {
        public PropertyType(IPaymentRepository paymentRepository)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Value);
            Field(x => x.City);
            Field(x => x.Family);
            Field(x => x.Street);
            Field<ListGraphType<PaymentType>>("payments",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name="last"}),
                resolve: context => {
                    var lastItemFilter = context.GetArgument<int?>("last");
                    return lastItemFilter != null
                    ? paymentRepository.GetAllForProperty(context.Source.Id, lastItemFilter.Value)
                    : paymentRepository.GetAllForProperty(context.Source.Id);
                    });
        }
    }
}
