using LojaDeTenis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Cryptography.Pkcs;

namespace LojaDeTenis.Models.ViewModels
{
    public class ProdutoViewModel
    {
        public Produto? Produto { get; set; }

        public int ProdutoId { get; set; }

        public int PedidoId { get; set; }

        public int ClienteId { get; set; }
    }
}
