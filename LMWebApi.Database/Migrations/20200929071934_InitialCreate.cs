using Microsoft.EntityFrameworkCore.Migrations;

namespace LMWebApi.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    ParentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Calories = table.Column<decimal>(nullable: false),
                    Proteins = table.Column<decimal>(nullable: false),
                    Carbohydrates = table.Column<decimal>(nullable: false),
                    Fats = table.Column<decimal>(nullable: false),
                    CategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProductId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInfo_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AminoAcids",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Alanine = table.Column<decimal>(nullable: false),
                    Arginine = table.Column<decimal>(nullable: false),
                    Valin = table.Column<decimal>(nullable: false),
                    Glycine = table.Column<decimal>(nullable: false),
                    Glutamine = table.Column<decimal>(nullable: false),
                    Isoleucine = table.Column<decimal>(nullable: false),
                    Leucine = table.Column<decimal>(nullable: false),
                    Lysine = table.Column<decimal>(nullable: false),
                    Methionine = table.Column<decimal>(nullable: false),
                    Proline = table.Column<decimal>(nullable: false),
                    Serine = table.Column<decimal>(nullable: false),
                    Tyrosine = table.Column<decimal>(nullable: false),
                    Threonine = table.Column<decimal>(nullable: false),
                    Tryptophan = table.Column<decimal>(nullable: false),
                    Phenylalanine = table.Column<decimal>(nullable: false),
                    Histidine = table.Column<decimal>(nullable: false),
                    Cystine = table.Column<decimal>(nullable: false),
                    ProductInfoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AminoAcids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AminoAcids_ProductInfo_ProductInfoId",
                        column: x => x.ProductInfoId,
                        principalTable: "ProductInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carbohydrates",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Fibres = table.Column<decimal>(nullable: false),
                    Starchs = table.Column<decimal>(nullable: false),
                    Sugar = table.Column<decimal>(nullable: false),
                    Galactose = table.Column<decimal>(nullable: false),
                    Glucose = table.Column<decimal>(nullable: false),
                    Sucrose = table.Column<decimal>(nullable: false),
                    Lactose = table.Column<decimal>(nullable: false),
                    Maltose = table.Column<decimal>(nullable: false),
                    Fructose = table.Column<decimal>(nullable: false),
                    ProductInfoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carbohydrates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carbohydrates_ProductInfo_ProductInfoId",
                        column: x => x.ProductInfoId,
                        principalTable: "ProductInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fats",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FatsVal = table.Column<decimal>(nullable: false),
                    Monounsaturated = table.Column<decimal>(nullable: false),
                    PolyunsaturatedFats = table.Column<decimal>(nullable: false),
                    SaturatedFats = table.Column<decimal>(nullable: false),
                    TransFats = table.Column<decimal>(nullable: false),
                    ProductInfoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fats_ProductInfo_ProductInfoId",
                        column: x => x.ProductInfoId,
                        principalTable: "ProductInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Minerals",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Iron = table.Column<decimal>(nullable: false),
                    Potassium = table.Column<decimal>(nullable: false),
                    Calcium = table.Column<decimal>(nullable: false),
                    Magnesium = table.Column<decimal>(nullable: false),
                    Manganese = table.Column<decimal>(nullable: false),
                    Copper = table.Column<decimal>(nullable: false),
                    Sodium = table.Column<decimal>(nullable: false),
                    Selenium = table.Column<decimal>(nullable: false),
                    Fluoride = table.Column<decimal>(nullable: false),
                    Phosphorus = table.Column<decimal>(nullable: false),
                    Zinc = table.Column<decimal>(nullable: false),
                    ProductInfoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minerals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Minerals_ProductInfo_ProductInfoId",
                        column: x => x.ProductInfoId,
                        principalTable: "ProductInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Others",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Alcohol = table.Column<decimal>(nullable: false),
                    Water = table.Column<decimal>(nullable: false),
                    Caffeine = table.Column<decimal>(nullable: false),
                    Theobromine = table.Column<decimal>(nullable: false),
                    Cinder = table.Column<decimal>(nullable: false),
                    ProductInfoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Others", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Others_ProductInfo_ProductInfoId",
                        column: x => x.ProductInfoId,
                        principalTable: "ProductInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sterols",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Cholesterol = table.Column<decimal>(nullable: false),
                    Phytosterols = table.Column<decimal>(nullable: false),
                    Stigmasterols = table.Column<decimal>(nullable: false),
                    Campesterols = table.Column<decimal>(nullable: false),
                    BetaSitosterols = table.Column<decimal>(nullable: false),
                    ProductInfoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sterols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sterols_ProductInfo_ProductInfoId",
                        column: x => x.ProductInfoId,
                        principalTable: "ProductInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vitamins",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    VitaminA = table.Column<decimal>(nullable: false),
                    VitaminB1 = table.Column<decimal>(nullable: false),
                    Betaine = table.Column<decimal>(nullable: false),
                    VitaminB2 = table.Column<decimal>(nullable: false),
                    VitaminB3 = table.Column<decimal>(nullable: false),
                    VitaminB5 = table.Column<decimal>(nullable: false),
                    VitaminB6 = table.Column<decimal>(nullable: false),
                    VitaminB9 = table.Column<decimal>(nullable: false),
                    VitaminB12 = table.Column<decimal>(nullable: false),
                    VitaminC = table.Column<decimal>(nullable: false),
                    VitaminD = table.Column<decimal>(nullable: false),
                    VitaminE = table.Column<decimal>(nullable: false),
                    VitaminK1 = table.Column<decimal>(nullable: false),
                    VitaminK2 = table.Column<decimal>(nullable: false),
                    VitaminB4 = table.Column<decimal>(nullable: false),
                    ProductInfoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vitamins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vitamins_ProductInfo_ProductInfoId",
                        column: x => x.ProductInfoId,
                        principalTable: "ProductInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AminoAcids_ProductInfoId",
                table: "AminoAcids",
                column: "ProductInfoId",
                unique: true,
                filter: "[ProductInfoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Carbohydrates_ProductInfoId",
                table: "Carbohydrates",
                column: "ProductInfoId",
                unique: true,
                filter: "[ProductInfoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Fats_ProductInfoId",
                table: "Fats",
                column: "ProductInfoId",
                unique: true,
                filter: "[ProductInfoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Minerals_ProductInfoId",
                table: "Minerals",
                column: "ProductInfoId",
                unique: true,
                filter: "[ProductInfoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Others_ProductInfoId",
                table: "Others",
                column: "ProductInfoId",
                unique: true,
                filter: "[ProductInfoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInfo_ProductId",
                table: "ProductInfo",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sterols_ProductInfoId",
                table: "Sterols",
                column: "ProductInfoId",
                unique: true,
                filter: "[ProductInfoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vitamins_ProductInfoId",
                table: "Vitamins",
                column: "ProductInfoId",
                unique: true,
                filter: "[ProductInfoId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AminoAcids");

            migrationBuilder.DropTable(
                name: "Carbohydrates");

            migrationBuilder.DropTable(
                name: "Fats");

            migrationBuilder.DropTable(
                name: "Minerals");

            migrationBuilder.DropTable(
                name: "Others");

            migrationBuilder.DropTable(
                name: "Sterols");

            migrationBuilder.DropTable(
                name: "Vitamins");

            migrationBuilder.DropTable(
                name: "ProductInfo");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
