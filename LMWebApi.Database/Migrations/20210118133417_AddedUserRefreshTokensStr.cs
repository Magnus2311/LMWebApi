using Microsoft.EntityFrameworkCore.Migrations;

namespace LMWebApi.Database.Migrations
{
    public partial class AddedUserRefreshTokensStr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshTokensStr",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTokensStr",
                table: "Users");
        }
    }
}
