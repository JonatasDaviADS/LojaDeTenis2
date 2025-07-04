using System.ComponentModel.DataAnnotations;

namespace LojaDeTenis.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Preço obrigatório")]
        [Range(0.01, 100000, ErrorMessage = "Preço deve estar entre R$0,01 e R$100.000")]
        public decimal Preco { get; set; }

        public string? ImagemUrl { get; set; }

        // Categoria está relacionada com Produto
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
