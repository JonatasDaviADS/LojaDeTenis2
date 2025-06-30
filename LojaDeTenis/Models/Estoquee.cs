namespace LojaDeTenis.Models
{
    public class Estoque
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
        public DateTime DataReabastecimento { get; set; }
    }
}
