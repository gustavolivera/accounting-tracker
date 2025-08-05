using Microsoft.EntityFrameworkCore;
using Domain.Entities; 

namespace Infrastructure.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<SituacaoExtratos> SituacaoExtratos { get; set; }
        public DbSet<SmtpSettings> SmtpSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
