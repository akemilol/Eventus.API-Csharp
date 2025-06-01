using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventus.API.Migrations
{
    /// <inheritdoc />
    public partial class SyncFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ABRIGO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeAbrigo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EnderecoAbrigo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CepAbrigo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CidadeAbrigo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UfAbrigo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LatitudeAbrig = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    LongitudeAbrig = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABRIGO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ALERTA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TipoAlerta = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CepAlerta = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALERTA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO_ABRIGO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UsuarioIdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AbrigosId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO_ABRIGO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO_ALERTA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UsuarioIdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AlertasId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataRecebimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO_ALERTA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CEP = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RELATOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RELATOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RELATOS_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RELATOS_UsuarioId",
                table: "RELATOS",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ABRIGO");

            migrationBuilder.DropTable(
                name: "ALERTA");

            migrationBuilder.DropTable(
                name: "RELATOS");

            migrationBuilder.DropTable(
                name: "USUARIO_ABRIGO");

            migrationBuilder.DropTable(
                name: "USUARIO_ALERTA");

            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
