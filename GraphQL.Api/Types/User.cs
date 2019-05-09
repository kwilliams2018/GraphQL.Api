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

            Field(user => user.UserId, type: typeof(IdGraphType)).Description("The ID of the user");
            Field(user => user.FirstName).Description("The user's first name");
            Field(user => user.LastName).Description("The user's last name");
            Field(user => user.Username).Description("The user's username");
            Field(user => user.Password).Description("The user's password");
        }
    }
}
