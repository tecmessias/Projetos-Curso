﻿// <auto-generated />
using System;
using JobPortal_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobPortal_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220730132545_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JobPortal_API.Models.AplicacaoTrabalho", b =>
                {
                    b.Property<int>("IdAplicacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAplicacao"), 1L, 1);

                    b.Property<DateTime>("DataAplicacao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdCandidato")
                        .HasColumnType("int");

                    b.Property<int?>("IdOferta")
                        .HasColumnType("int");

                    b.Property<bool>("aplicacaoAceite")
                        .HasColumnType("bit");

                    b.HasKey("IdAplicacao");

                    b.HasIndex("IdCandidato");

                    b.HasIndex("IdOferta");

                    b.ToTable("AplicacaoTrabalho");
                });

            modelBuilder.Entity("JobPortal_API.Models.Candidato", b =>
                {
                    b.Property<int>("IdCandidato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCandidato"), 1L, 1);

                    b.Property<DateTime?>("DataNasc")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FileCV")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LinkedIn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Telefone")
                        .HasColumnType("int");

                    b.HasKey("IdCandidato");

                    b.ToTable("Candidato");
                });

            modelBuilder.Entity("JobPortal_API.Models.CV", b =>
                {
                    b.Property<int>("IdCV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCV"), 1L, 1);

                    b.Property<string>("Competencias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Educacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpProfissional")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdCandidatoCv")
                        .HasColumnType("int");

                    b.Property<string>("Interesses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCV");

                    b.HasIndex("IdCandidatoCv");

                    b.ToTable("CV");
                });

            modelBuilder.Entity("JobPortal_API.Models.Empresa", b =>
                {
                    b.Property<int>("IdEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpresa"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NoFuncionarios")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Telefone")
                        .HasColumnType("int");

                    b.Property<string>("ZonaAtuacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEmpresa");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("JobPortal_API.Models.Foto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("FotoPerfil")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("IdCandidatoFoto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCandidatoFoto");

                    b.ToTable("Foto");
                });

            modelBuilder.Entity("JobPortal_API.Models.LogoEmpresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdEmpresaFoto")
                        .HasColumnType("int");

                    b.Property<byte[]>("Logo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdEmpresaFoto");

                    b.ToTable("LogoEmpresa");
                });

            modelBuilder.Entity("JobPortal_API.Models.OfertaEmprego", b =>
                {
                    b.Property<int>("IdOferta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOferta"), 1L, 1);

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("int");

                    b.Property<string>("Jornada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localização")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegimeTrabalho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requisitos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Salario")
                        .HasColumnType("real");

                    b.Property<string>("TipoContrato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("VagaDisponivel")
                        .HasColumnType("bit");

                    b.HasKey("IdOferta");

                    b.HasIndex("IdEmpresa");

                    b.ToTable("OfertaEmprego");
                });

            modelBuilder.Entity("JobPortal_API.Models.AplicacaoTrabalho", b =>
                {
                    b.HasOne("JobPortal_API.Models.Candidato", "Candidato")
                        .WithMany("AplicacaoTrabalhos")
                        .HasForeignKey("IdCandidato");

                    b.HasOne("JobPortal_API.Models.OfertaEmprego", "OfertaEmprego")
                        .WithMany("AplicacaoTrabalhos")
                        .HasForeignKey("IdOferta");

                    b.Navigation("Candidato");

                    b.Navigation("OfertaEmprego");
                });

            modelBuilder.Entity("JobPortal_API.Models.CV", b =>
                {
                    b.HasOne("JobPortal_API.Models.Candidato", "IdCandidato")
                        .WithMany("CVs")
                        .HasForeignKey("IdCandidatoCv");

                    b.Navigation("IdCandidato");
                });

            modelBuilder.Entity("JobPortal_API.Models.Foto", b =>
                {
                    b.HasOne("JobPortal_API.Models.Candidato", "Candidato")
                        .WithMany("Fotos")
                        .HasForeignKey("IdCandidatoFoto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");
                });

            modelBuilder.Entity("JobPortal_API.Models.LogoEmpresa", b =>
                {
                    b.HasOne("JobPortal_API.Models.Empresa", "empresa")
                        .WithMany("Logos")
                        .HasForeignKey("IdEmpresaFoto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("empresa");
                });

            modelBuilder.Entity("JobPortal_API.Models.OfertaEmprego", b =>
                {
                    b.HasOne("JobPortal_API.Models.Empresa", "Empresa")
                        .WithMany("OfertaEmpregos")
                        .HasForeignKey("IdEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("JobPortal_API.Models.Candidato", b =>
                {
                    b.Navigation("AplicacaoTrabalhos");

                    b.Navigation("CVs");

                    b.Navigation("Fotos");
                });

            modelBuilder.Entity("JobPortal_API.Models.Empresa", b =>
                {
                    b.Navigation("Logos");

                    b.Navigation("OfertaEmpregos");
                });

            modelBuilder.Entity("JobPortal_API.Models.OfertaEmprego", b =>
                {
                    b.Navigation("AplicacaoTrabalhos");
                });
#pragma warning restore 612, 618
        }
    }
}
