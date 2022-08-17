using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OEBB_Pruefstand.Persistence.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pruefer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    V_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    N_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pruefer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Antriebseinheiten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bezeichnung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zustand = table.Column<bool>(type: "bit", nullable: false),
                    Leistung = table.Column<int>(type: "int", nullable: false),
                    Prüflaufnummer = table.Column<int>(type: "int", nullable: false),
                    Typ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrueferID = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antriebseinheiten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Antriebseinheiten_Pruefer_PrueferID",
                        column: x => x.PrueferID,
                        principalTable: "Pruefer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Antriebskomponenten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bezeichnung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Leistung = table.Column<int>(type: "int", nullable: false),
                    Baujahr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AntriebseinheitsID = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antriebskomponenten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Antriebskomponenten_Antriebseinheiten_AntriebseinheitsID",
                        column: x => x.AntriebseinheitsID,
                        principalTable: "Antriebseinheiten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Antriebseinheiten_PrueferID",
                table: "Antriebseinheiten",
                column: "PrueferID");

            migrationBuilder.CreateIndex(
                name: "IX_Antriebskomponenten_AntriebseinheitsID",
                table: "Antriebskomponenten",
                column: "AntriebseinheitsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Antriebskomponenten");

            migrationBuilder.DropTable(
                name: "Antriebseinheiten");

            migrationBuilder.DropTable(
                name: "Pruefer");
        }
    }
}
