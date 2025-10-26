using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class controlleFarm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistroFazenda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    AreaHectares = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroFazenda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistroUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false, defaultValueSql: "lower(hex(randomblob(16)))"),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Classifica = table.Column<string>(type: "TEXT", nullable: false),
                    DateCadastro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistroMaquina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    TipoMaquina = table.Column<string>(type: "TEXT", nullable: false),
                    FarmId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DateCadastro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroMaquina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroMaquina_RegistroFazenda_FarmId",
                        column: x => x.FarmId,
                        principalTable: "RegistroFazenda",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RegistroPlantacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TipoPlantio = table.Column<string>(type: "TEXT", nullable: false),
                    QuantidadeHectares = table.Column<double>(type: "REAL", nullable: false),
                    FarmId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DateCadastro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroPlantacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroPlantacao_RegistroFazenda_FarmId",
                        column: x => x.FarmId,
                        principalTable: "RegistroFazenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFarm",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FarmId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TipoAcesso = table.Column<string>(type: "TEXT", nullable: false),
                    DataVicuclo = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFarm", x => new { x.UserId, x.FarmId });
                    table.ForeignKey(
                        name: "FK_UserFarm_RegistroFazenda_FarmId",
                        column: x => x.FarmId,
                        principalTable: "RegistroFazenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFarm_RegistroUsuario_UserId",
                        column: x => x.UserId,
                        principalTable: "RegistroUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManutencaoMaquina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TipoManutencao = table.Column<string>(type: "TEXT", nullable: false),
                    ValorManutencao = table.Column<decimal>(type: "TEXT", nullable: false),
                    Observacao = table.Column<string>(type: "TEXT", nullable: true),
                    MaquinaId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DateManutencao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManutencaoMaquina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManutencaoMaquina_RegistroMaquina_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "RegistroMaquina",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustoPlantacaos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NomeCusto = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    Observacao = table.Column<string>(type: "TEXT", nullable: true),
                    PlantacaoId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DateCusto = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustoPlantacaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustoPlantacaos_RegistroPlantacao_PlantacaoId",
                        column: x => x.PlantacaoId,
                        principalTable: "RegistroPlantacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistroFinanca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    CustoPlantacaoId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ManutencaoMaquinaId = table.Column<Guid>(type: "TEXT", nullable: true),
                    FarmId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroFinanca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroFinanca_CustoPlantacaos_CustoPlantacaoId",
                        column: x => x.CustoPlantacaoId,
                        principalTable: "CustoPlantacaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroFinanca_ManutencaoMaquina_ManutencaoMaquinaId",
                        column: x => x.ManutencaoMaquinaId,
                        principalTable: "ManutencaoMaquina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroFinanca_RegistroFazenda_FarmId",
                        column: x => x.FarmId,
                        principalTable: "RegistroFazenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustoPlantacaos_PlantacaoId",
                table: "CustoPlantacaos",
                column: "PlantacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ManutencaoMaquina_MaquinaId",
                table: "ManutencaoMaquina",
                column: "MaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroFinanca_CustoPlantacaoId",
                table: "RegistroFinanca",
                column: "CustoPlantacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroFinanca_FarmId",
                table: "RegistroFinanca",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroFinanca_ManutencaoMaquinaId",
                table: "RegistroFinanca",
                column: "ManutencaoMaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroMaquina_FarmId",
                table: "RegistroMaquina",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPlantacao_FarmId",
                table: "RegistroPlantacao",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFarm_FarmId",
                table: "UserFarm",
                column: "FarmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroFinanca");

            migrationBuilder.DropTable(
                name: "UserFarm");

            migrationBuilder.DropTable(
                name: "CustoPlantacaos");

            migrationBuilder.DropTable(
                name: "ManutencaoMaquina");

            migrationBuilder.DropTable(
                name: "RegistroUsuario");

            migrationBuilder.DropTable(
                name: "RegistroPlantacao");

            migrationBuilder.DropTable(
                name: "RegistroMaquina");

            migrationBuilder.DropTable(
                name: "RegistroFazenda");
        }
    }
}
