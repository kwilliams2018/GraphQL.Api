using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQL.DataModel;

namespace GraphQL.Api.Types
{
    public class User : ObjectGraphType<DataModel.User>
    {
        public User()
        {
            Name = "User";

            Field(user => user.UserId, type: typeof(IntGraphType));
            Field(user => user.FirstName);
            Field(user => user.LastName);
            Field(user => user.Username);
            Field(user => user.Password);
        }
    }
}
