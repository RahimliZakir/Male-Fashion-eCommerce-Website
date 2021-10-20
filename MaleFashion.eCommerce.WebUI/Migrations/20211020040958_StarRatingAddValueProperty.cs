using Microsoft.EntityFrameworkCore.Migrations;

namespace MaleFashion.eCommerce.WebUI.Migrations
{
    public partial class StarRatingAddValueProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "StarRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "StarRatings");
        }
    }
}
