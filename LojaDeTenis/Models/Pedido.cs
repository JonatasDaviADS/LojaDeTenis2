using System.ComponentModel.DataAnnotations;

namespace LojaDeTenis.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Data do pedido obrigatória")]
        public DateTime Data { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public NotaFiscal? NotaFiscal { get; set; }

        [Required(ErrorMessage = "Status obrigatório")]
        public string? Status { get; set; }

        public ICollection<ProdPedi> ProdutosPedidos { get; set; }
    }
}
