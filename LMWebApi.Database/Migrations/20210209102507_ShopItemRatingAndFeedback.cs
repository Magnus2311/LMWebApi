using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMWebApi.Database.Migrations
{
    public partial class ShopItemRatingAndFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "ShopItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ShopItemFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<decimal>(nullable: false),
                    Feedback = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ShopItemId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItemFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopItemFeedbacks_ShopItems_ShopItemId",
                        column: x => x.ShopItemId,
                        principalTable: "ShopItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopItemFeedbacks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopItemFeedbacks_ShopItemId",
                table: "ShopItemFeedbacks",
                column: "ShopItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItemFeedbacks_UserId",
                table: "ShopItemFeedbacks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopItemFeedbacks");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "ShopItems");
        }
    }
}
