using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LojaDeTenis.Models;
using System.Collections;

namespace LojaDeTenis.Data
{
    public class LojaDeTenisContext : DbContext
    {
        public LojaDeTenisContext(DbContextOptions<LojaDeTenisContext> options)
            : base(options)
        {
        }

        // DbSets representando tabelas no banco, nomes no plural
        public DbSet<Categoria> Categoria { get; set; } = default!;
        public DbSet<Produto> Produto { get; set; } = default!;
        public DbSet<Cliente> Cliente { get; set; } = default!;
        public DbSet<Pedido> Pedidos { get; set; } = default!;
        public DbSet<ProdPedi> ProdPedi { get; set; } = default!;
        public DbSet<Estoque> Estoque { get; set; } = default!;
        public DbSet<Usuario> Usuario { get; set; } = default!;
        public DbSet<NotaFiscal> NotaFiscail { get; set; } = default!;
        public DbSet<Pagamento> Pagamento { get; set; } = default!;
        public object NotaFiscal { get; internal set; }
        public IEnumerable Clientes { get; internal set; }
        public IEnumerable Categorias { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração relacionamento NotaFiscal <-> Pedido
            modelBuilder.Entity<NotaFiscal>()
                .HasOne(n => n.Pedido)
                .WithOne(p => p.NotaFiscal)
                .HasForeignKey<NotaFiscal>(n => n.PedidoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração relacionamento NotaFiscal <-> Cliente
            modelBuilder.Entity<NotaFiscal>()
                .HasOne(n => n.Cliente)
                .WithMany()
                .HasForeignKey(n => n.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    // Classe estática para popular dados iniciais
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
