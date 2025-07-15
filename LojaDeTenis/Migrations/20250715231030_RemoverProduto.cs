using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaDeTenis.Migrations
{
    public partial class RemoverProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscal_Produto_ProdutoId",
                table: "NotaFiscal");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscal_ProdutoId",
                table: "NotaFiscal");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "NotaFiscal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "NotaFiscal",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscal_ProdutoId",
                table: "NotaFiscal",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscal_Produto_ProdutoId",
                table: "NotaFiscal",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
