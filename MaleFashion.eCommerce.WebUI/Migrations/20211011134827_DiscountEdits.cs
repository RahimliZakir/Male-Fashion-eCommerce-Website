using Microsoft.EntityFrameworkCore.Migrations;

namespace MaleFashion.eCommerce.WebUI.Migrations
{
    public partial class DiscountEdits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMainCollections_Campaigns_CampaignId",
                table: "ProductMainCollections");

            migrationBuilder.DropIndex(
                name: "IX_ProductMainCollections_CampaignId",
                table: "ProductMainCollections");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "ProductMainCollections");

            migrationBuilder.DropColumn(
                name: "PriceNew",
                table: "ProductMainCollections");

            migrationBuilder.CreateTable(
                name: "ProductCampaignCollections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCollectionId = table.Column<int>(nullable: false),
                    CampaignId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCampaignCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCampaignCollections_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCampaignCollections_ProductMainCollections_ProductCollectionId",
                        column: x => x.ProductCollectionId,
                        principalTable: "ProductMainCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCampaignCollections_CampaignId",
                table: "ProductCampaignCollections",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCampaignCollections_ProductCollectionId",
                table: "ProductCampaignCollections",
                column: "ProductCollectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCampaignCollections");

            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "ProductMainCollections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceNew",
                table: "ProductMainCollections",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductMainCollections_CampaignId",
                table: "ProductMainCollections",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMainCollections_Campaigns_CampaignId",
                table: "ProductMainCollections",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
