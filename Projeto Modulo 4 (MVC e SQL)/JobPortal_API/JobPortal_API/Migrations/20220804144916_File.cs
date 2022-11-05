using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal_API.Migrations
{
    public partial class File : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileCV",
                table: "Candidato");

            migrationBuilder.RenameColumn(
                name: "aplicacaoAceite",
                table: "AplicacaoTrabalho",
                newName: "AplicacaoAceite");

            migrationBuilder.AlterColumn<string>(
                name: "AplicacaoAceite",
                table: "AplicacaoTrabalho",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AplicacaoAceite",
                table: "AplicacaoTrabalho",
                newName: "aplicacaoAceite");

            migrationBuilder.AddColumn<byte[]>(
                name: "FileCV",
                table: "Candidato",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "aplicacaoAceite",
                table: "AplicacaoTrabalho",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
