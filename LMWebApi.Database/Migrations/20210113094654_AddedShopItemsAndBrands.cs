using Microsoft.EntityFrameworkCore.Migrations;

namespace LMWebApi.Database.Migrations
{
    public partial class AddedShopItemsAndBrands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AvailableQuantity",
                table: "ShopItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "ShopItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ShopItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ShopItems",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ShopItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Usage",
                table: "ShopItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_BrandId",
                table: "ShopItems",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopItems_Brands_BrandId",
                table: "ShopItems",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopItems_Brands_BrandId",
                table: "ShopItems");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_ShopItems_BrandId",
                table: "ShopItems");

            migrationBuilder.DropColumn(
                name: "AvailableQuantity",
                table: "ShopItems");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "ShopItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ShopItems");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ShopItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ShopItems");

            migrationBuilder.DropColumn(
                name: "Usage",
                table: "ShopItems");
        }
    }
}
