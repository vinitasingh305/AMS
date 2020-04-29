using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetManagement.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ManufacturingDate",
                table: "Asset",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ManufacturingDate",
                table: "Asset",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
