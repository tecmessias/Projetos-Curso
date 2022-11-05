using JobPortal_API.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal_API.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public virtual DbSet<AplicacaoTrabalho> AplicacaoTrabalho { get; set; }
        public virtual DbSet<Candidato> Candidato { get; set; }
        public virtual DbSet<CV> CV { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Foto> Foto { get; set; }
        public virtual DbSet<LogoEmpresa> LogoEmpresa { get; set; }
        public virtual DbSet<OfertaEmprego> OfertaEmprego { get; set; }
    }
}
