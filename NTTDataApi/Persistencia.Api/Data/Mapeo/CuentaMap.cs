using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Servicios.Api.Entity;

namespace Persistencia.Api.Data.Mapeo
{
    class CuentaMap : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> entity)
        {
            entity.HasKey(e => e.IdCuenta)
                    .HasName("PK__Cuentas__BBC6DF32D1F94AB3");

            entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

            entity.Property(e => e.Estado).HasColumnName("estado");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");

            entity.Property(e => e.NumCuenta)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("numCuenta");

            entity.Property(e => e.SaldoIncial)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("saldoIncial");

            entity.Property(e => e.TipoCuenta)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tipoCuenta")
                .IsFixedLength(true);

            entity.HasOne(d => d.Cliente)
                .WithMany(p => p.Cuentas)
                .HasForeignKey(d => d.IdCliente)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CuentaCliente");
        }
    }
}
