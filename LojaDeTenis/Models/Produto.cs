using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaDeTenis.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Descrição obrigatória")]
        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Preço obrigatório")]
        [Range(0.01, 100000, ErrorMessage = "Preço deve estar entre R$0,01 e R$100.000")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Imagem obrigatória")]
        public string? ImagemUrl { get; set; }

        [Required(ErrorMessage = "Categoria obrigatória")]
        public int CategoriaId { get; set; } // FK

        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; } // Navegação
    }
}
