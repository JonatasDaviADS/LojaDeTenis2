using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LojaDeTenis.Models;

namespace LojaDeTenis.Data
{
    public class LojaDeTenisContext : DbContext
    {
        public LojaDeTenisContext (DbContextOptions<LojaDeTenisContext> options)
            : base(options)
        {
        }


        public DbSet<LojaDeTenis.Models.Categoria> Categoria { get; set; } = default!;
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
