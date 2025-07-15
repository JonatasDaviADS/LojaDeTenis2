using System.ComponentModel.DataAnnotations;

namespace LojaDeTenis.Models
{
    public class NotaFiscal
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O número da nota é obrigatório")]
        [StringLength(20, ErrorMessage = "O número deve ter no máximo 20 caracteres")]
        public string? Numero { get; set; }

        [Required(ErrorMessage = "A série é obrigatória")]
        [StringLength(10, ErrorMessage = "A série deve ter no máximo 10 caracteres")]
        public string? Serie { get; set; }

        [Required(ErrorMessage = "A chave de acesso é obrigatória")]
        [StringLength(44, MinimumLength = 44, ErrorMessage = "A chave de acesso deve ter 44 caracteres")]
        public string? ChaveAcesso { get; set; }

        [Required(ErrorMessage = "A data de emissão é obrigatória")]
        public DateTime DataEmissao { get; set; }

        [Required(ErrorMessage = "O valor total é obrigatório")]
        [Range(0.01, 100000, ErrorMessage = "O valor deve estar entre R$0,01 e R$100.000,00")]
        public decimal ValorTotal { get; set; }

        //[Required(ErrorMessage = "O produto é obrigatório")]
        //public int ProdutoId { get; set; }
        //public Produto? Produto { get; set; }

        [Required(ErrorMessage = "O pedido é obrigatório")]
        public int PedidoId { get; set; }
        public Pedido? Pedido { get; set; }

        [Required(ErrorMessage = "O cliente é obrigatório")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public string? XmlNotaFiscal { get; set; }

        [Required(ErrorMessage = "O status é obrigatório")]
        [StringLength(20, ErrorMessage = "O status deve ter no máximo 20 caracteres")]
        public string? Status { get; set; }
    }
}