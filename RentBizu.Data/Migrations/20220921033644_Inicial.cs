using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentBizu.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locador",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locatario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanoConta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Produto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    DataOferta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InicioPlano = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FimPlano = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoginPlanoContaPlano = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenhaPlanoContaPlano = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusPlanoConta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoConta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanoConta_Locador_LocadorId",
                        column: x => x.LocadorId,
                        principalTable: "Locador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aluguel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanoContaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocatarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluguel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aluguel_Locatario_LocatarioId",
                        column: x => x.LocatarioId,
                        principalTable: "Locatario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aluguel_PlanoConta_PlanoContaId",
                        column: x => x.PlanoContaId,
                        principalTable: "PlanoConta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluguel_LocatarioId",
                table: "Aluguel",
                column: "LocatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Aluguel_PlanoContaId",
                table: "Aluguel",
                column: "PlanoContaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoConta_LocadorId",
                table: "PlanoConta",
                column: "LocadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluguel");

            migrationBuilder.DropTable(
                name: "Locatario");

            migrationBuilder.DropTable(
                name: "PlanoConta");

            migrationBuilder.DropTable(
                name: "Locador");
        }
    }
}
