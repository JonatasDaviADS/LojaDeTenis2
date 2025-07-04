using System.ComponentModel.DataAnnotations;

namespace LojaDeTenis.Models
{
    public class Estoque
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }


        [Required(ErrorMessage = "A quantidade é obrigatória")]
        [Range(0, 10000, ErrorMessage = "A quantidade deve ser entre 0 e 10.000")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "A data de reabastecimento é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataReabastecimento { get; set; }
    }
}
