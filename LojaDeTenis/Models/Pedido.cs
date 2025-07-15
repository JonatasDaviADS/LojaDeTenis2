using System;
using System.ComponentModel.DataAnnotations;

namespace LojaDeTenis.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data do Pedido")]
        public DateTime Data { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;  // null-forgiving para indicar que será preenchido
        // public Categoria Categoria { get; set; } = null!;

        [Required]
        public string Status { get; set; } = string.Empty; // propriedade com inicialização para evitar warnings

        // Relacionamentos        

        public ICollection<ProdPedi> ProdutosPedidos { get; set; } = new List<ProdPedi>();


    }
}
