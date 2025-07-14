using System.ComponentModel.DataAnnotations;

namespace LojaDeTenis.Models
{
    public class ProdPedi
    {
        public int Id { get; set; }

        // Relação com Produto
        [Required(ErrorMessage = "Produto obrigatório")]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        // Relação com Pedido

        [Required(ErrorMessage = "Pedido obrigatório")]
        public int PedidoId { get; set; }
        public Pedido? Pedido { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Quantidade mínima é 1")]
        public int Quantidade { get; set; }


        [Range(0.01, 10000.00, ErrorMessage = "Preço deve ser entre R$0,01 e R$10.000,00")]
        [DataType(DataType.Currency)]
        public decimal PrecoUnitario { get; set; }
    }
}
