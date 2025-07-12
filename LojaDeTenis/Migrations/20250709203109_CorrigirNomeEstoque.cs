using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaDeTenis.Migrations
{
    public partial class CorrigirNomeEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscal_Cliente_ClienteId",
                table: "NotaFiscal");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscal_Pedido_PedidoId",
                table: "NotaFiscal");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_Pedido_PedidoId",
                table: "Pagamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdPedi_Pedido_PedidoId",
                table: "ProdPedi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotaFiscal",
                table: "NotaFiscal");

            migrationBuilder.RenameTable(
                name: "Pedido",
                newName: "Pedidos");

            migrationBuilder.RenameTable(
                name: "NotaFiscal",
                newName: "NotaFiscail");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedidos",
                newName: "IX_Pedidos_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_NotaFiscal_PedidoId",
                table: "NotaFiscail",
                newName: "IX_NotaFiscail_PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_NotaFiscal_ClienteId",
                table: "NotaFiscail",
                newName: "IX_NotaFiscail_ClienteId");

            migrationBuilder.AlterColumn<string>(
                name: "ImagemUrl",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Produto",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Categoria",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "NotaFiscalId",
                table: "Pedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotaFiscail",
                table: "NotaFiscail",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_CategoriaId",
                table: "Pedidos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscail_Cliente_ClienteId",
                table: "NotaFiscail",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscail_Pedidos_PedidoId",
                table: "NotaFiscail",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_Pedidos_PedidoId",
                table: "Pagamento",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Categoria_CategoriaId",
                table: "Pedidos",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Cliente_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdPedi_Pedidos_PedidoId",
                table: "ProdPedi",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscail_Cliente_ClienteId",
                table: "NotaFiscail");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscail_Pedidos_PedidoId",
                table: "NotaFiscail");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_Pedidos_PedidoId",
                table: "Pagamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Categoria_CategoriaId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Cliente_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdPedi_Pedidos_PedidoId",
                table: "ProdPedi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_CategoriaId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotaFiscail",
                table: "NotaFiscail");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Pedidos");

            migrationBuilder.RenameTable(
                name: "Pedidos",
                newName: "Pedido");

            migrationBuilder.RenameTable(
                name: "NotaFiscail",
                newName: "NotaFiscal");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedido",
                newName: "IX_Pedido_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_NotaFiscail_PedidoId",
                table: "NotaFiscal",
                newName: "IX_NotaFiscal_PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_NotaFiscail_ClienteId",
                table: "NotaFiscal",
                newName: "IX_NotaFiscal_ClienteId");

            migrationBuilder.AlterColumn<string>(
                name: "ImagemUrl",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Pedido",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "NotaFiscalId",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotaFiscal",
                table: "NotaFiscal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscal_Cliente_ClienteId",
                table: "NotaFiscal",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscal_Pedido_PedidoId",
                table: "NotaFiscal",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_Pedido_PedidoId",
                table: "Pagamento",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                table: "Pedido",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdPedi_Pedido_PedidoId",
                table: "ProdPedi",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
