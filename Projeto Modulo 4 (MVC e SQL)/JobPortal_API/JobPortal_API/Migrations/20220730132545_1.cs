using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal_API.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidato",
                columns: table => new
                {
                    IdCandidato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<int>(type: "int", nullable: true),
                    Morada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNasc = table.Column<DateTime>(type: "Date", nullable: true),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileCV = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.IdCandidato);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<int>(type: "int", nullable: true),
                    NoFuncionarios = table.Column<int>(type: "int", nullable: true),
                    ZonaAtuacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.IdEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "CV",
                columns: table => new
                {
                    IdCV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localizacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Educacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpProfissional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Competencias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interesses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCandidatoCv = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV", x => x.IdCV);
                    table.ForeignKey(
                        name: "FK_CV_Candidato_IdCandidatoCv",
                        column: x => x.IdCandidatoCv,
                        principalTable: "Candidato",
                        principalColumn: "IdCandidato");
                });

            migrationBuilder.CreateTable(
                name: "Foto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCandidatoFoto = table.Column<int>(type: "int", nullable: false),
                    FotoPerfil = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foto_Candidato_IdCandidatoFoto",
                        column: x => x.IdCandidatoFoto,
                        principalTable: "Candidato",
                        principalColumn: "IdCandidato",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogoEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresaFoto = table.Column<int>(type: "int", nullable: false),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogoEmpresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogoEmpresa_Empresa_IdEmpresaFoto",
                        column: x => x.IdEmpresaFoto,
                        principalTable: "Empresa",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfertaEmprego",
                columns: table => new
                {
                    IdOferta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salario = table.Column<float>(type: "real", nullable: true),
                    Jornada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localização = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegimeTrabalho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Requisitos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VagaDisponivel = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaEmprego", x => x.IdOferta);
                    table.ForeignKey(
                        name: "FK_OfertaEmprego_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AplicacaoTrabalho",
                columns: table => new
                {
                    IdAplicacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOferta = table.Column<int>(type: "int", nullable: true),
                    IdCandidato = table.Column<int>(type: "int", nullable: true),
                    DataAplicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    aplicacaoAceite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplicacaoTrabalho", x => x.IdAplicacao);
                    table.ForeignKey(
                        name: "FK_AplicacaoTrabalho_Candidato_IdCandidato",
                        column: x => x.IdCandidato,
                        principalTable: "Candidato",
                        principalColumn: "IdCandidato");
                    table.ForeignKey(
                        name: "FK_AplicacaoTrabalho_OfertaEmprego_IdOferta",
                        column: x => x.IdOferta,
                        principalTable: "OfertaEmprego",
                        principalColumn: "IdOferta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AplicacaoTrabalho_IdCandidato",
                table: "AplicacaoTrabalho",
                column: "IdCandidato");

            migrationBuilder.CreateIndex(
                name: "IX_AplicacaoTrabalho_IdOferta",
                table: "AplicacaoTrabalho",
                column: "IdOferta");

            migrationBuilder.CreateIndex(
                name: "IX_CV_IdCandidatoCv",
                table: "CV",
                column: "IdCandidatoCv");

            migrationBuilder.CreateIndex(
                name: "IX_Foto_IdCandidatoFoto",
                table: "Foto",
                column: "IdCandidatoFoto");

            migrationBuilder.CreateIndex(
                name: "IX_LogoEmpresa_IdEmpresaFoto",
                table: "LogoEmpresa",
                column: "IdEmpresaFoto");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaEmprego_IdEmpresa",
                table: "OfertaEmprego",
                column: "IdEmpresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplicacaoTrabalho");

            migrationBuilder.DropTable(
                name: "CV");

            migrationBuilder.DropTable(
                name: "Foto");

            migrationBuilder.DropTable(
                name: "LogoEmpresa");

            migrationBuilder.DropTable(
                name: "OfertaEmprego");

            migrationBuilder.DropTable(
                name: "Candidato");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
