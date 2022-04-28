using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5I_jovanovicS_progettoInformatica.Migrations
{
    public partial class CreazioneDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Muscoli",
                columns: table => new
                {
                    MuscoloID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descrizione = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muscoli", x => x.MuscoloID);
                });

            migrationBuilder.CreateTable(
                name: "Esercizi",
                columns: table => new
                {
                    EsercizioID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeEsercizio = table.Column<string>(type: "TEXT", nullable: true),
                    Descrizione = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroSerie = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroRipetizioni = table.Column<int>(type: "INTEGER", nullable: false),
                    SecondiRecupero = table.Column<int>(type: "INTEGER", nullable: false),
                    MuscoloID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Esercizi", x => x.EsercizioID);
                    table.ForeignKey(
                        name: "FK_Esercizi_Muscoli_MuscoloID",
                        column: x => x.MuscoloID,
                        principalTable: "Muscoli",
                        principalColumn: "MuscoloID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Esercizi_MuscoloID",
                table: "Esercizi",
                column: "MuscoloID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Esercizi");

            migrationBuilder.DropTable(
                name: "Muscoli");
        }
    }
}
