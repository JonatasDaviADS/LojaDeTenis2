namespace LojaDeTenis.Models
{
    public class NotaFiscal
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Serie { get; set; }
        public string ChaveAcesso { get; set; }
        public DateTime DataEmissao { get; set; }
        public decimal ValorTotal { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public string XmlNotaFiscal { get; set; }
        public string Status { get; set; }
    }
}
