using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaDeTenis.Migrations
{
    public partial class Removernota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscal_Pedido_PedidoId",
                table: "NotaFiscal");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscal_PedidoId",
                table: "NotaFiscal");

            migrationBuilder.DropColumn(
                name: "NotaFiscalId",
                table: "Pedido");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscal_PedidoId",
                table: "NotaFiscal",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscal_Pedido_PedidoId",
                table: "NotaFiscal",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscal_Pedido_PedidoId",
                table: "NotaFiscal");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscal_PedidoId",
                table: "NotaFiscal");

            migrationBuilder.AddColumn<int>(
                name: "NotaFiscalId",
                table: "Pedido",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscal_PedidoId",
                table: "NotaFiscal",
                column: "PedidoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscal_Pedido_PedidoId",
                table: "NotaFiscal",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
