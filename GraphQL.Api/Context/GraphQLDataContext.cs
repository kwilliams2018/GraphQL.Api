﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using GraphQL.DataModel;

namespace GraphQL.Api.Context
{
    public class GraphQLDataContext : DbContext
    {
        public GraphQLDataContext() { }
        public GraphQLDataContext(DbContextOptions<GraphQLDataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<DataModel.Type> Types { get; set; }
    }
}
