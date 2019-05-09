using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;

namespace GraphQL.Migrations
{
    [Migration(001)]
    public class Sprint_1 : Migration
    {
        public override void Up()
        {
            // Create Tables
            Create.Table("User")
                .WithColumn("UserId").AsInt32().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString(255).NotNullable()
                .WithColumn("LastName").AsString(255).NotNullable()
                .WithColumn("Username").AsString(int.MaxValue).NotNullable()
                .WithColumn("Password").AsString(int.MaxValue).NotNullable();
        }

        public override void Down()
        {
            // Delete Tables
            Delete.Table("User");
        }
    }
}
