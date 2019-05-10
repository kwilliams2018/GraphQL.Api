using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace GraphQL.Api.Types
{
    public class Type : ObjectGraphType<DataModel.Type>
    {
        public Type()
        {
            Name = "Type";

            Field(t => t.TypeId, type: typeof(IntGraphType));
            Field(t => t.Name);
            Field(t => t.Label);
            Field(t => t.Description);
        }
    }
}