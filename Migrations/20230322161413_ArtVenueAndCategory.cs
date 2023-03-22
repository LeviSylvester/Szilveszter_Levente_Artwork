using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Szilveszter_Levente_Artwork.Migrations
{
    public partial class ArtVenueAndCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VenueID",
                table: "Artwork",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ArtworkCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtworkID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtworkCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArtworkCategory_Artwork_ArtworkID",
                        column: x => x.ArtworkID,
                        principalTable: "Artwork",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtworkCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artwork_VenueID",
                table: "Artwork",
                column: "VenueID");

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkCategory_ArtworkID",
                table: "ArtworkCategory",
                column: "ArtworkID");

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkCategory_CategoryID",
                table: "ArtworkCategory",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Artwork_Venue_VenueID",
                table: "Artwork",
                column: "VenueID",
                principalTable: "Venue",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artwork_Venue_VenueID",
                table: "Artwork");

            migrationBuilder.DropTable(
                name: "ArtworkCategory");

            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Artwork_VenueID",
                table: "Artwork");

            migrationBuilder.DropColumn(
                name: "VenueID",
                table: "Artwork");
        }
    }
}
