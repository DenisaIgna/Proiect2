using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect2.Migrations
{
    public partial class CategorieMasina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProducatorID",
                table: "Masina",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Producator",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeProducator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieMasina",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasinaID = table.Column<int>(nullable: false),
                    CategorieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieMasina", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieMasina_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieMasina_Masina_MasinaID",
                        column: x => x.MasinaID,
                        principalTable: "Masina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Masina_ProducatorID",
                table: "Masina",
                column: "ProducatorID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieMasina_CategorieID",
                table: "CategorieMasina",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieMasina_MasinaID",
                table: "CategorieMasina",
                column: "MasinaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Masina_Producator_ProducatorID",
                table: "Masina",
                column: "ProducatorID",
                principalTable: "Producator",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masina_Producator_ProducatorID",
                table: "Masina");

            migrationBuilder.DropTable(
                name: "CategorieMasina");

            migrationBuilder.DropTable(
                name: "Producator");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Masina_ProducatorID",
                table: "Masina");

            migrationBuilder.DropColumn(
                name: "ProducatorID",
                table: "Masina");
        }
    }
}
