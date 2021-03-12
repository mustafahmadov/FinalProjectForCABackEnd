using Microsoft.EntityFrameworkCore.Migrations;

namespace ZodiacWatchStore.Migrations
{
    public partial class SaleProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Sales");

            migrationBuilder.AddColumn<string>(
                name: "CustomerFatherName",
                table: "Sales",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SaleStatus",
                table: "Sales",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerFatherName",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "SaleStatus",
                table: "Sales");

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
