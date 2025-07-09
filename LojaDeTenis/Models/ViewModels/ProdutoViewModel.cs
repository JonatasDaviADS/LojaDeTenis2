using LojaDeTenis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace LojaDeTenis.Models.ViewModels
{
    public class ProdutoViewModel
    {
        public Produto? Produto { get; set; }
        public IEnumerable<SelectListItem>? Categoria { get; set; }
        public List<SelectListItem> Categorias { get; internal set; }
    }
}
