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
        public LojaDeTenisContext(DbContextOptions<LojaDeTenisContext> options)
            : base(options)
        {
        }

        // ✅ DbSets (representam tabelas no banco)
        public DbSet<Categoria> Categoria { get; set; } = default!;
        public DbSet<Produto> Produto { get; set; } = default!;
        public DbSet<Cliente> Cliente { get; set; } = default!;
        public DbSet<Pedido> Pedido { get; set; } = default!;
        public DbSet<ProdPedi> ProdPedi { get; set; } = default!;
        public DbSet<Estoque> Estoque { get; set; } = default!;
        public DbSet<Usuario> Usuario { get; set; } = default!;
        public DbSet<NotaFiscal> NotaFiscal { get; set; } = default!;
        public DbSet<Pagamento> Pagamento { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ❌ Impede exclusões em cascata problemáticas
            modelBuilder.Entity<NotaFiscal>()
                .HasOne(n => n.Pedido)
                .WithOne(p => p.NotaFiscal)
                .HasForeignKey<NotaFiscal>(n => n.PedidoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NotaFiscal>()
                .HasOne(n => n.Cliente)
                .WithMany()
                .HasForeignKey(n => n.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    // ✅ Seed de categorias
    public static class SeedData
    {
        public static void Inicializar(LojaDeTenisContext context)
        {
            if (context.Categoria.Any())
                return; // Já existem categorias

            var categoriasIniciais = new List<Categoria>
            {
                new Categoria { Nome = "Tênis Casual" },
                new Categoria { Nome = "Tênis Esportivo" },
                new Categoria { Nome = "Tênis de Corrida" },
                new Categoria { Nome = "Tênis Infantil" }
            };

            context.Categoria.AddRange(categoriasIniciais);
            context.SaveChanges();
        }
    }
}
