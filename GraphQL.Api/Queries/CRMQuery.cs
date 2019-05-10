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
    public class CRMQuery : ObjectGraphType
    {
        public CRMQuery(GraphQLDataContext dataContext)
        {
            // User Queries
            Field<User>(
                "User",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => 
                {
                    var id = context.GetArgument<int>("id");
                    var user = dataContext.Users
                        .Where(u => u.UserId == id)
                        .FirstOrDefault();
                    return user;
                }
            );

            Field<ListGraphType<User>>(
                "Users",
                resolve: context =>
                {
                    var users = dataContext.Users;
                    return users;
                }
            );

            // Class Queries
            Field<Class>(
                "Class",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var classObject = dataContext.Classes
                        .Include("Location")
                        .Include("Type")
                        .Where(c => c.ClassId == id)
                        .FirstOrDefault();
                    return classObject;
                }
            );

            // Location Queries
            Field<Location>(
                "Location",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var location = dataContext.Locations
                        .Include("Type")
                        .Where(l => l.LocationId == id)
                        .FirstOrDefault();
                    return location;
                }
            );

            // Type Queries
            Field<Types.Type>(
                "Type",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var type = dataContext.Types
                        .Where(t => t.TypeId == id)
                        .FirstOrDefault();
                    return type;
                }
            );
        }
    }
}
