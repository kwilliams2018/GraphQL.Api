using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQL.DataModel;

namespace GraphQL.Api.Types
{
    public class Class : ObjectGraphType<DataModel.Class>
    {
        public Class()
        {
            Name = "Class";

            Field(c => c.ClassId, type: typeof(IntGraphType));
            Field(c => c.TypeId);
            Field<Type>("Type");
            Field(c => c.LocationId);
            Field<Location>("Location");
            Field(c => c.Name);
        }
    }
}