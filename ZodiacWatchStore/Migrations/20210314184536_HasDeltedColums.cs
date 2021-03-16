using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZodiacWatchStore.Migrations
{
    public partial class HasDeltedColums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "PaymentTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasDeleted",
                table: "PaymentTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Guarantees",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasDeleted",
                table: "Guarantees",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "HasDeleted",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Guarantees");

            migrationBuilder.DropColumn(
                name: "HasDeleted",
                table: "Guarantees");
        }
    }
}
