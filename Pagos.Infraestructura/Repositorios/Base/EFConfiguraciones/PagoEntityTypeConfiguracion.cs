using Pagos.Dominio.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Pagos.Infraestructura.Repositorios.Base.EFConfiguraciones
{
    public class PagoEntityTypeConfiguracion : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            builder.ToTable("Pagos");
            builder.HasKey(c => c.IdPago);
            builder.Property(c => c.Monto).HasPrecision(18, 2);
        }
    }
}
