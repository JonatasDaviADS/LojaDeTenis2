using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LojaDeTenis.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da categoria obrigatório")]
        [StringLength(100, ErrorMessage = "O nome da categoria deve ter no máximo 100 caracteres")]
        public string? Nome { get; set; }

        // Relação: Uma categoria possui muitos produtos
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
