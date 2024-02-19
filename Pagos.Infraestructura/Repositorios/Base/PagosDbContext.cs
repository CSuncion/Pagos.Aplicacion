using Microsoft.EntityFrameworkCore;
using Pagos.Dominio.Models;

namespace Pagos.Infraestructura.Repositorios.Base
{
    public class PagosDbContext : DbContext
    {
        public PagosDbContext(DbContextOptions<PagosDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Pago> Pagos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configurando las entidades en archivos de tipos separados
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PagosDbContext).Assembly);
            #endregion
        }
    }
}