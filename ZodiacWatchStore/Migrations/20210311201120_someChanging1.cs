using Microsoft.EntityFrameworkCore.Migrations;

namespace ZodiacWatchStore.Migrations
{
    public partial class someChanging1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Sales",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_PaymentTypeId",
                table: "Sales",
                column: "PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_PaymentType_PaymentTypeId",
                table: "Sales",
                column: "PaymentTypeId",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_PaymentType_PaymentTypeId",
                table: "Sales");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropIndex(
                name: "IX_Sales_PaymentTypeId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Sales");
        }
    }
}
