using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EHT.WebApp.Migrations.DatabaseDb
{
    public partial class CompanyAddRemark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "Company",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remark",
                table: "Company");
        }
    }
}
