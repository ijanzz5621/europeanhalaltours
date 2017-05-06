using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EHT.WebApp.Data;

namespace EHT.WebApp.Migrations.DatabaseDb
{
    [DbContext(typeof(DatabaseDbContext))]
    [Migration("20170506025419_ChangeTableFieldsLength")]
    partial class ChangeTableFieldsLength
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("EHT.WebApp.Models.Database.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(200);

                    b.Property<string>("Code")
                        .HasMaxLength(20);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20);

                    b.Property<string>("Remark")
                        .HasMaxLength(500);

                    b.HasKey("ID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("EHT.WebApp.Models.Database.Package", b =>
                {
                    b.Property<string>("PackageID")
                        .HasMaxLength(10);

                    b.Property<int>("Day");

                    b.Property<string>("Event");

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("PackageID", "Day");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("EHT.WebApp.Models.Database.PackageMain", b =>
                {
                    b.Property<string>("PackageID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("PackageName")
                        .HasMaxLength(50);

                    b.HasKey("PackageID");

                    b.ToTable("PackageMain");
                });
        }
    }
}
