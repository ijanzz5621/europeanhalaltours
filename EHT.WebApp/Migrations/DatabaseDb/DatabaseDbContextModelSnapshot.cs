﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EHT.WebApp.Data;

namespace EHT.WebApp.Migrations.DatabaseDb
{
    [DbContext(typeof(DatabaseDbContext))]
    partial class DatabaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("EHT.WebApp.Models.Database.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Code");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("ID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("EHT.WebApp.Models.Database.Package", b =>
                {
                    b.Property<string>("PackageID");

                    b.Property<int>("Day");

                    b.Property<string>("Event");

                    b.Property<string>("Title");

                    b.HasKey("PackageID", "Day");

                    b.ToTable("Package");
                });
        }
    }
}
