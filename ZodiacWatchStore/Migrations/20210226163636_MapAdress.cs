using Microsoft.EntityFrameworkCore.Migrations;

namespace ZodiacWatchStore.Migrations
{
    public partial class MapAdress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Bios");

            migrationBuilder.AddColumn<string>(
                name: "LogoBlack",
                table: "Bios",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LogoWhite",
                table: "Bios",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MapAdress",
                table: "Bios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoBlack",
                table: "Bios");

            migrationBuilder.DropColumn(
                name: "LogoWhite",
                table: "Bios");

            migrationBuilder.DropColumn(
                name: "MapAdress",
                table: "Bios");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Bios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
