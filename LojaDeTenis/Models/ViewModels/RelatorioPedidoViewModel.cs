namespace LojaDeTenis.Models.ViewModels
{
    public class RelatorioPedidoViewModel
    {
        public DateTime DataPedido { get; set; }
        public string? NomeCliente { get; set; }
        public int QuantidadeProdutos { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
