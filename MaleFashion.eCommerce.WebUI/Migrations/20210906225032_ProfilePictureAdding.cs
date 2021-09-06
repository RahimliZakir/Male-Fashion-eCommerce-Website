using Microsoft.EntityFrameworkCore.Migrations;

namespace MaleFashion.eCommerce.WebUI.Migrations
{
    public partial class ProfilePictureAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                schema: "Membership",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                schema: "Membership",
                table: "Users");
        }
    }
}
