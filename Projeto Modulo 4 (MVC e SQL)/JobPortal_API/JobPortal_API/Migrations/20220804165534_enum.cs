using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal_API.Migrations
{
    public partial class @enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AplicacaoAceite",
                table: "AplicacaoTrabalho");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AplicacaoAceite",
                table: "AplicacaoTrabalho",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
