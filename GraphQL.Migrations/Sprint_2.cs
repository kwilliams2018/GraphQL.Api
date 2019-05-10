using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;

namespace GraphQL.Migrations
{
    [Migration(002)]
    public class Sprint_2 : Migration
    {
        public override void Up()
        {
            // Create Tables
            Create.Table("Class")
                .WithColumn("ClassId").AsInt32().PrimaryKey().Identity()
                .WithColumn("TypeId").AsInt32().NotNullable()
                .WithColumn("LocationId").AsInt32().NotNullable()
                .WithColumn("Name").AsString(255).NotNullable();

            Create.Table("Type")
                .WithColumn("TypeId").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Label").AsString(255).NotNullable()
                .WithColumn("Description").AsString(int.MaxValue).NotNullable();

            Create.Table("Location")
                .WithColumn("LocationId").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Label").AsString(255).NotNullable()
                .WithColumn("TypeId").AsInt32().NotNullable()
                .WithColumn("City").AsString(255).NotNullable()
                .WithColumn("State").AsString(255).NotNullable();

            // Populate tables
            Insert.IntoTable("Class")
                .Row(new { TypeId = 1, LocationId = 1, Name = "Krav Maga" })
                .Row(new { TypeId = 2, LocationId = 1, Name = "Cardio Kickboxing" })
                .Row(new { TypeId = 2, LocationId = 1, Name = "Fitness Bootcamp" });

            Insert.IntoTable("Type")
                .Row(new { Name = "self_defense", Label = "Self-Defense", Description = "Learn how to defend yourself" })
                .Row(new { Name = "fitness", Label = "Fitness", Description = "Get in shape" })
                .Row(new { Name = "building", Label = "Building", Description = "Phsyical Building" });

            Insert.IntoTable("Location")
                .Row(new { Name = "fitness_gym", Label = "Fitness Gym", TypeId = 3, City = "Springfield", State = "Missouri" });
        }

        public override void Down()
        {
            Delete.Table("Class");
            Delete.Table("Type");
            Delete.Table("Location");
        }
    }
}
