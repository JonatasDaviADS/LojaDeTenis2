using System.ComponentModel.DataAnnotations;

namespace LojaDeTenis.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Data do pedido obrigatória")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }


        [Required(ErrorMessage = "Cliente obrigatório")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public NotaFiscal? NotaFiscal { get; set; }

        [Required(ErrorMessage = "Status obrigatório")]
        [StringLength(20, ErrorMessage = "Status pode ter no máximo 20 caracteres")]
        public string? Status { get; set; }

        public ICollection<ProdPedi> ProdutosPedidos { get; set; } = new List<ProdPedi>();
    }
}
