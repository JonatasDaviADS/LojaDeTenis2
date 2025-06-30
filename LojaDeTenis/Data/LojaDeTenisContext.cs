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
        // public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<LojaDeTenis.Models.Produto> Produto { get; set; } = default!;
        public DbSet<LojaDeTenis.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<LojaDeTenis.Models.Pedido> Pedido { get; set; } = default!;
        public DbSet<LojaDeTenis.Models.ProdPedi> ProdPedi { get; set; } = default!;
        public DbSet<LojaDeTenis.Models.Estoque> Estoque { get; set; } = default!;
        public DbSet<LojaDeTenis.Models.Usuario> Usuario { get; set; } = default!;
        public DbSet<LojaDeTenis.Models.NotaFiscal> NotaFiscal { get; set; } = default!;
        public DbSet<LojaDeTenis.Models.Pagamento> Pagamento { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Evita conflito de deleção em cascata entre NotaFiscal -> Pedido e NotaFiscal -> Cliente
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
    
    }
