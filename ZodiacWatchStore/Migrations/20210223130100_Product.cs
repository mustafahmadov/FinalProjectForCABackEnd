using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZodiacWatchStore.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BandTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    HasDeleted = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: false),
                    HasDeleted = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseThicks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    HasDeleted = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseThicks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlassTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    HasDeleted = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlassTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guarantees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guarantees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mechanisms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    HasDeleted = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanisms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterProtections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterProtections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: false),
                    WatchCode = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    SaleCount = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    HasDeleted = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    ViewCount = table.Column<int>(nullable: false),
                    MechanismId = table.Column<int>(nullable: false),
                    BandTypeId = table.Column<int>(nullable: false),
                    WaterProtectionId = table.Column<int>(nullable: false),
                    CaseThickId = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    GlassTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_BandTypes_BandTypeId",
                        column: x => x.BandTypeId,
                        principalTable: "BandTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_CaseThicks_CaseThickId",
                        column: x => x.CaseThickId,
                        principalTable: "CaseThicks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_GlassTypes_GlassTypeId",
                        column: x => x.GlassTypeId,
                        principalTable: "GlassTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Mechanisms_MechanismId",
                        column: x => x.MechanismId,
                        principalTable: "Mechanisms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_WaterProtections_WaterProtectionId",
                        column: x => x.WaterProtectionId,
                        principalTable: "WaterProtections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: false),
                    HasDeleted = table.Column<bool>(nullable: false),
                    DeletedTime = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BandTypeId",
                table: "Products",
                column: "BandTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CaseThickId",
                table: "Products",
                column: "CaseThickId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GlassTypeId",
                table: "Products",
                column: "GlassTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MechanismId",
                table: "Products",
                column: "MechanismId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_WaterProtectionId",
                table: "Products",
                column: "WaterProtectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guarantees");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "BandTypes");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "CaseThicks");

            migrationBuilder.DropTable(
                name: "GlassTypes");

            migrationBuilder.DropTable(
                name: "Mechanisms");

            migrationBuilder.DropTable(
                name: "WaterProtections");
        }
    }
}
