using LojaDeTenis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace LojaDeTenis.Models.ViewModels
{
    public class ProdutoViewModel
    {
        public Produto Produto { get; set; }
        public IEnumerable<SelectListItem> Categorias { get; set; }
    }
}
