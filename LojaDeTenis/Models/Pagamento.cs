using System.ComponentModel.DataAnnotations;

namespace LojaDeTenis.Models
{
    public class Pagamento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O valor do pagamento é obrigatório")]
        [Range(0.01, 10000, ErrorMessage = "O valor deve estar entre R$0,01 e R$10.000")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A data do pagamento é obrigatória")]
        public DateTime DataPagamento { get; set; }

        public int PedidoId { get; set; }
        public Pedido? Pedido { get; set; }

        [Required(ErrorMessage = "O método de pagamento é obrigatório")]
        [EnumDataType(typeof(MetodoPagamento), ErrorMessage = "Método de pagamento inválido")]
        public string MetodoPagamento { get; set; }
    }
}
