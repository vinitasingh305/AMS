using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetManagement.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetName = table.Column<string>(maxLength: 50, nullable: false),
                    TypeOfItem = table.Column<string>(maxLength: 50, nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ItemDesc = table.Column<string>(maxLength: 50, nullable: true),
                    ItemBrand = table.Column<string>(maxLength: 500, nullable: true),
                    ManufacturingDate = table.Column<DateTime>(nullable: false),
                    BUName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetName = table.Column<string>(maxLength: 50, nullable: false),
                    ItemBrand = table.Column<int>(maxLength: 50, nullable: false),
                    ItemDesc = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(maxLength: 50, nullable: true),
                    Lastname = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Contactnumber = table.Column<int>(maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(maxLength: 50, nullable: false),
                    PasswordSalt = table.Column<byte[]>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Asset",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false),
                    AssetId = table.Column<int>(nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Asset", x => new { x.CustomerId, x.AssetId });
                    table.ForeignKey(
                        name: "FK_CustomerAsset_Asset",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAsset_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Asset_AssetId",
                table: "Customer_Asset",
                column: "AssetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer_Asset");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
