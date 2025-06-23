namespace LojaDeTenis.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }

        // Categoria está relacionada com Produto
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
