using Microsoft.EntityFrameworkCore.Migrations;

namespace MaleFashion.eCommerce.WebUI.Migrations
{
    public partial class FixesCommentReply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorImagePath",
                table: "Replies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Replies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorSurname",
                table: "Replies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorImagePath",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorSurname",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorImagePath",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "AuthorSurname",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "AuthorImagePath",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AuthorSurname",
                table: "Comments");
        }
    }
}
