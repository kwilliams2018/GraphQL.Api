using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using GraphQL.Api.Context;
using GraphQL.Api.Types;

namespace GraphQL.Api.Queries
{
    public class User : ObjectGraphType
    {
        public User(GraphQLDataContext dataContext)
        {
            Field<Types.User>(
                "User",
                arguments: new QueryArguments(new QueryArgument<IGraphType> { Name = "id", Description = "The ID of the user" }),
                resolve: context => 
                {
                    var id = context.GetArgument<int>("id");
                    var user = dataContext.Users
                        .Where(u => u.UserId == id)
                        .FirstOrDefault();
                    return user;
                }
            );

            Field<ListGraphType<Types.User>>(
                "Users",
                resolve: context =>
                {
                    var users = dataContext.Users;
                    return users;
                }
            );
        }
    }
}
