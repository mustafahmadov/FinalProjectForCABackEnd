using Microsoft.EntityFrameworkCore.Migrations;

namespace ZodiacWatchStore.Migrations
{
    public partial class someChanging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress",
                table: "Sales",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "ShippingPrice",
                table: "Sales",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingAddress",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ShippingPrice",
                table: "Sales");
        }
    }
}
