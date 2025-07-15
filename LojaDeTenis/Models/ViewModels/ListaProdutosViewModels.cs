namespace LojaDeTenis.Models.ViewModels
{
    public class ListaProdutosViewModels
    {
        public Pedido Pedido{ get; set; }

        public List<Produto> Produtos{ get; set; } = new List<Produto>();
    }
}
