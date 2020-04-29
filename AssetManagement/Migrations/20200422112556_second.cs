using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetManagement.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ItemBrand",
                table: "Customer",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ItemBrand",
                table: "Customer",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(long),
                oldMaxLength: 50);
        }
    }
}
