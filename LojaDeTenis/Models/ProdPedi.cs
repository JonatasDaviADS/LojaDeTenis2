using System.ComponentModel.DataAnnotations;

namespace LojaDeTenis.Models
{
    public class ProdPedi
    {
        public int Id { get; set; }

        // Relação com Produto
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        // Relação com Pedido
        public int PedidoId { get; set; }
        public Pedido? Pedido { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantidade mínima é 1")]
        public int Quantidade { get; set; }

        public decimal PrecoUnitario { get; set; }
    }
}
