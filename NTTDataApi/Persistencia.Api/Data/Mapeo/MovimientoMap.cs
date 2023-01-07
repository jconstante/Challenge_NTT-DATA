using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Servicios.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Api.Data.Mapeo
{
    class MovimientoMap : IEntityTypeConfiguration<Movimiento>
    {
        public void Configure(EntityTypeBuilder<Movimiento> entity)
        {
            entity.HasKey(e => e.IdMov)
                    .HasName("PK__Movimien__3DC69A4F707E7B5D");

            entity.Property(e => e.IdMov).HasColumnName("idMov");

            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");

            entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

            entity.Property(e => e.Saldo)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("saldo");

            entity.Property(e => e.TipoMov)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tipoMov")
                .IsFixedLength(true);

            entity.Property(e => e.Valor)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("valor");

            entity.HasOne(d => d.Cuenta)
                .WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdCuenta)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovCtas");
        }
    }
}
