using Microsoft.EntityFrameworkCore.Migrations;

namespace KonsiLoja.Migrations
{
    public partial class Primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendedors",
                columns: table => new
                {
                    VendedorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedors", x => x.VendedorId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    CPF = table.Column<int>(nullable: false),
                    VendedoresId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_Vendedors_VendedoresId",
                        column: x => x.VendedoresId,
                        principalTable: "Vendedors",
                        principalColumn: "VendedorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    ContratoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroContrato = table.Column<int>(nullable: false),
                    ValorContrato = table.Column<decimal>(nullable: false),
                    SaldoDevedor = table.Column<decimal>(nullable: false),
                    ParcelasTotais = table.Column<int>(nullable: false),
                    ParcelasPagas = table.Column<int>(nullable: false),
                    ValorParcela = table.Column<int>(nullable: false),
                    VendedoresId = table.Column<int>(nullable: true),
                    ClientesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.ContratoId);
                    table.ForeignKey(
                        name: "FK_Contratos_Clientes_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_Vendedors_VendedoresId",
                        column: x => x.VendedoresId,
                        principalTable: "Vendedors",
                        principalColumn: "VendedorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_VendedoresId",
                table: "Clientes",
                column: "VendedoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ClientesId",
                table: "Contratos",
                column: "ClientesId",
                unique: true,
                filter: "[ClientesId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_VendedoresId",
                table: "Contratos",
                column: "VendedoresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Vendedors");
        }
    }
}
