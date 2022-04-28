using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5I_jovanovicS_progettoInformatica.Migrations
{
    public partial class AggiuntoVideoURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoURL",
                table: "Esercizi",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoURL",
                table: "Esercizi");
        }
    }
}
