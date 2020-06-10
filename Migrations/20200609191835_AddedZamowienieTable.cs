using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kolokwium_probne.Migrations
{
    public partial class AddedZamowienieTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BakeryOrders",
                columns: table => new
                {
                    IdZamowienie = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrzyjecia = table.Column<DateTime>(nullable: false),
                    DataRealizacji = table.Column<DateTime>(nullable: false),
                    Uwagi = table.Column<string>(nullable: true),
                    IdKlient = table.Column<int>(nullable: false),
                    IdPracownik = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakeryOrders", x => x.IdZamowienie);
                    table.ForeignKey(
                        name: "FK_BakeryOrders_BakeryClient_IdKlient",
                        column: x => x.IdKlient,
                        principalTable: "BakeryClient",
                        principalColumn: "IdKlient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BakeryOrders_BakeryPracownik_IdPracownik",
                        column: x => x.IdPracownik,
                        principalTable: "BakeryPracownik",
                        principalColumn: "IdPracownik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BakeryOrders_IdKlient",
                table: "BakeryOrders",
                column: "IdKlient");

            migrationBuilder.CreateIndex(
                name: "IX_BakeryOrders_IdPracownik",
                table: "BakeryOrders",
                column: "IdPracownik");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BakeryOrders");
        }
    }
}
