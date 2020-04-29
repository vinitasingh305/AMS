using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetManagement.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssetName",
                table: "Customer",
                newName: "Customername");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Customername",
                table: "Customer",
                newName: "AssetName");
        }
    }
}
