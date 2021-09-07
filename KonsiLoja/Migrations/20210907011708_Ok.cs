using Microsoft.EntityFrameworkCore.Migrations;

namespace KonsiLoja.Migrations
{
    public partial class Ok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RelatorioGeral",
                columns: table => new
                {
                    RelatorioGeralId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(nullable: false),
                    ContratoId = table.Column<int>(nullable: false),
                    VendedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatorioGeral", x => x.RelatorioGeralId);
                    table.ForeignKey(
                        name: "FK_RelatorioGeral_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelatorioGeral_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "ContratoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelatorioGeral_Vendedors_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedors",
                        principalColumn: "VendedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelatorioGeral_ClienteId",
                table: "RelatorioGeral",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatorioGeral_ContratoId",
                table: "RelatorioGeral",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatorioGeral_VendedorId",
                table: "RelatorioGeral",
                column: "VendedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelatorioGeral");
        }
    }
}
