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

            modelBuilder.Entity<ProdPedi>()
            .HasKey(pp => pp.Id); // chave primária

            modelBuilder.Entity<ProdPedi>()
                .HasOne(pp => pp.Pedido)
                .WithMany(p => p.ProdutosPedidos)
                .HasForeignKey(pp => pp.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProdPedi>()
                .HasOne(pp => pp.Produto)
                .WithMany()
                .HasForeignKey(pp => pp.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pedido>()
                .HasMany(p => p.ProdutosPedidos)
                .WithOne(pp => pp.Pedido)
                .HasForeignKey(pp => pp.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    // Classe estática para popular dados iniciais
    public static class SeedData
    {
        public static void Inicializar(LojaDeTenisContext context)
        {            
            context.SaveChanges();
        }
    }
}
