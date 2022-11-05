using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BibliotecaMVCEF.Models;


namespace BibliotecaMVCEF
{
    public partial class BibliotecaContext : DbContext
    {
        public BibliotecaContext()
        {
        }

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Leitor> Leitor { get; set; }
        public virtual DbSet<Obras> Obras { get; set; }
        public virtual DbSet<Requisicoes> Requisicoes { get; set; }
        public virtual DbSet<VRequisicoesObra> VRequisicoesObra { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=alenote;Initial Catalog=Biblioteca;User Id = teste; Password = bolinha; TrustServerCertificate = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Requisicoes>(entity =>
            {
                entity.HasOne(d => d.IdLeitorNavigation)
                    .WithMany(p => p.Requisicoes)
                    .HasForeignKey(d => d.IdLeitor)
                    .HasConstraintName("FK_Requisicoes_Leitor");

                entity.HasOne(d => d.IdObraNavigation)
                    .WithMany(p => p.Requisicoes)
                    .HasForeignKey(d => d.IdObra)
                    .HasConstraintName("FK_Requisicoes_Obras");
            });

            modelBuilder.Entity<VRequisicoesObra>(entity =>
            {
                entity.ToView("V_Requisicoes_Obra");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}