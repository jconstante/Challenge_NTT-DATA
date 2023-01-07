using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Servicios.Api.Entity;

namespace Persistencia.Api.Data.Mapeo
{
    class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entity)
        {

            entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__885457EE219FCCEF");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");

            entity.Property(e => e.Estado).HasColumnName("estado");

            entity.Property(e => e.FechaCreacion)
                        .HasColumnType("datetime")
                        .HasColumnName("fechaCreacion");

            entity.Property(e => e.FechaModificacion)
                        .HasColumnType("datetime")
                        .HasColumnName("fechaModificacion");

            entity.Property(e => e.IdPersona).HasColumnName("idPersona");

            entity.Property(e => e.Password)
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnName("password");

            entity.HasOne(d => d.Persona)
                        .WithMany(p => p.Clientes)
                        .HasForeignKey(d => d.IdPersona)
                        //.OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ClientePersona");
        }
    }
}
