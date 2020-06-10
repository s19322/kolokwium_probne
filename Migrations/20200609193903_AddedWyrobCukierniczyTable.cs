using Microsoft.EntityFrameworkCore.Migrations;

namespace kolokwium_probne.Migrations
{
    public partial class AddedWyrobCukierniczyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BakeryProduct",
                columns: table => new
                {
                    IdWyrobCukierniczy = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: true),
                    CenaZaSztuke = table.Column<float>(nullable: false),
                    typ = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakeryProduct", x => x.IdWyrobCukierniczy);
                });

            migrationBuilder.CreateTable(
                name: "BakeryProduct_Order",
                columns: table => new
                {
                    IdWyrobCukierniczy = table.Column<int>(nullable: false),
                    IdZamowienie = table.Column<int>(nullable: false),
                    Ilosc = table.Column<int>(nullable: false),
                    Uwagi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_BakeryProduct_Order_BakeryProduct_IdWyrobCukierniczy",
                        column: x => x.IdWyrobCukierniczy,
                        principalTable: "BakeryProduct",
                        principalColumn: "IdWyrobCukierniczy",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BakeryProduct_Order_BakeryOrders_IdZamowienie",
                        column: x => x.IdZamowienie,
                        principalTable: "BakeryOrders",
                        principalColumn: "IdZamowienie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BakeryProduct_Order_IdWyrobCukierniczy",
                table: "BakeryProduct_Order",
                column: "IdWyrobCukierniczy");

            migrationBuilder.CreateIndex(
                name: "IX_BakeryProduct_Order_IdZamowienie",
                table: "BakeryProduct_Order",
                column: "IdZamowienie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BakeryProduct_Order");

            migrationBuilder.DropTable(
                name: "BakeryProduct");
        }
    }
}
