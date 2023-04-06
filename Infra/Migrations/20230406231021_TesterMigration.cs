using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class TesterMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServicoId",
                table: "Barbearias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barbearias_Servicos_ServicoId",
                table: "Barbearias");

            migrationBuilder.DropIndex(
                name: "IX_Barbearias_ServicoId",
                table: "Barbearias");

            migrationBuilder.DropColumn(
                name: "ServicoId",
                table: "Barbearias");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BarbeariaId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BarbeariaId",
                table: "AspNetUsers",
                column: "BarbeariaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Barbearias_BarbeariaId",
                table: "AspNetUsers",
                column: "BarbeariaId",
                principalTable: "Barbearias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
