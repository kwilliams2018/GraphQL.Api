using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace GraphQL.Api.Types
{
    public class Location : ObjectGraphType<DataModel.Location>
    {
        public Location()
        {
            Name = "Location";

            Field(l => l.LocationId, type: typeof(IntGraphType));
            Field(l => l.Name);
            Field(l => l.Label);
            Field(l => l.TypeId);
            Field<Type>("Type");
            Field(l => l.City);
            Field(l => l.State);
        }
    }
}