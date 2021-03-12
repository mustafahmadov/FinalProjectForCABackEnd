using Microsoft.EntityFrameworkCore.Migrations;

namespace ZodiacWatchStore.Migrations
{
    public partial class SaleProduct1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Information",
                table: "Sales",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Information",
                table: "Sales");
        }
    }
}
