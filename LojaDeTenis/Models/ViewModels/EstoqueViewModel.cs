namespace LojaDeTenis.Models.ViewModels
{
    public class EstoqueViewModel
    {
        public Estoque Estoque { get; set; }

        public List<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
