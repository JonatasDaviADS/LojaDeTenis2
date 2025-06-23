namespace LojaDeTenis.Models
{
    public class Pedido
    {
        public int Id { get; set; }  

        public DateTime Data { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public NotaFiscal NotaFiscal { get; set; }

        public string Status { get; set; }

        public ICollection<ProdPedi> ProdutosPedidos { get; set; }
    }
}
