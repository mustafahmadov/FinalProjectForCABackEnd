using Microsoft.EntityFrameworkCore.Migrations;

namespace ZodiacWatchStore.Migrations
{
    public partial class someChanging2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_PaymentType_PaymentTypeId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentType",
                table: "PaymentType");

            migrationBuilder.RenameTable(
                name: "PaymentType",
                newName: "PaymentTypes");

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Sales",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Sales",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerPhone",
                table: "Sales",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerSurname",
                table: "Sales",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentTypes",
                table: "PaymentTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_PaymentTypes_PaymentTypeId",
                table: "Sales",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_PaymentTypes_PaymentTypeId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentTypes",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CustomerPhone",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CustomerSurname",
                table: "Sales");

            migrationBuilder.RenameTable(
                name: "PaymentTypes",
                newName: "PaymentType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentType",
                table: "PaymentType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_PaymentType_PaymentTypeId",
                table: "Sales",
                column: "PaymentTypeId",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
