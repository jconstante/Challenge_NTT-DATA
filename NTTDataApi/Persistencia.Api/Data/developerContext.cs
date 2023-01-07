using Microsoft.EntityFrameworkCore;
using Persistencia.Api.Data.Mapeo;
using Servicios.Api.Entity;


#nullable disable

namespace Persistencia.Api.Data
{
    public partial class developerContext : DbContext
    {
        public developerContext()
        {
        }

        public developerContext(DbContextOptions<developerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");
            modelBuilder.ApplyConfiguration(new PersonaMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new CuentaMap());
            modelBuilder.ApplyConfiguration(new MovimientoMap());

            OnModelCreatingPartial(modelBuilder);

            #region
            //modelBuilder.Entity<Cliente>(entity =>
            //{
            //    entity.HasKey(e => e.IdCliente)
            //        .HasName("PK__Clientes__885457EE219FCCEF");

            //    entity.Property(e => e.IdCliente).HasColumnName("idCliente");

            //    entity.Property(e => e.Estado).HasColumnName("estado");

            //    entity.Property(e => e.FechaCreacion)
            //        .HasColumnType("datetime")
            //        .HasColumnName("fechaCreacion");

            //    entity.Property(e => e.FechaModificacion)
            //        .HasColumnType("datetime")
            //        .HasColumnName("fechaModificacion");

            //    entity.Property(e => e.IdPersona).HasColumnName("idPersona");

            //    entity.Property(e => e.Password)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("password");

            //    entity.HasOne(d => d.Persona)
            //        .WithMany(p => p.Clientes)
            //        .HasForeignKey(d => d.IdPersona)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_ClientePersona");
            //});

            //modelBuilder.Entity<Cuenta>(entity =>
            //{
            //    entity.HasKey(e => e.IdCuenta)
            //        .HasName("PK__Cuentas__BBC6DF32D1F94AB3");

            //    entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

            //    entity.Property(e => e.Estado).HasColumnName("estado");

            //    entity.Property(e => e.FechaCreacion)
            //        .HasColumnType("datetime")
            //        .HasColumnName("fechaCreacion");

            //    entity.Property(e => e.FechaModificacion)
            //        .HasColumnType("datetime")
            //        .HasColumnName("fechaModificacion");

            //    entity.Property(e => e.IdCliente).HasColumnName("idCliente");

            //    entity.Property(e => e.NumCuenta)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .HasColumnName("numCuenta");

            //    entity.Property(e => e.SaldoIncial)
            //        .HasColumnType("decimal(12, 2)")
            //        .HasColumnName("saldoIncial");

            //    entity.Property(e => e.TipoCuenta)
            //        .IsRequired()
            //        .HasMaxLength(1)
            //        .IsUnicode(false)
            //        .HasColumnName("tipoCuenta")
            //        .IsFixedLength(true);

            //    entity.HasOne(d => d.Cliente)
            //        .WithMany(p => p.Cuentas)
            //        .HasForeignKey(d => d.IdCliente)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_CuentaCliente");
            //});

            //modelBuilder.Entity<Movimiento>(entity =>
            //{
            //    entity.HasKey(e => e.IdMov)
            //        .HasName("PK__Movimien__3DC69A4F707E7B5D");

            //    entity.Property(e => e.IdMov).HasColumnName("idMov");

            //    entity.Property(e => e.Fecha)
            //        .HasColumnType("datetime")
            //        .HasColumnName("fecha");

            //    entity.Property(e => e.FechaModificacion)
            //        .HasColumnType("datetime")
            //        .HasColumnName("fechaModificacion");

            //    entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

            //    entity.Property(e => e.Saldo)
            //        .HasColumnType("decimal(12, 2)")
            //        .HasColumnName("saldo");

            //    entity.Property(e => e.TipoMov)
            //        .IsRequired()
            //        .HasMaxLength(1)
            //        .IsUnicode(false)
            //        .HasColumnName("tipoMov")
            //        .IsFixedLength(true);

            //    entity.Property(e => e.Valor)
            //        .HasColumnType("decimal(12, 2)")
            //        .HasColumnName("valor");

            //    entity.HasOne(d => d.Cuenta)
            //        .WithMany(p => p.Movimientos)
            //        .HasForeignKey(d => d.IdCuenta)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_MovCtas");
            //});

            //modelBuilder.Entity<Persona>(entity =>
            //{
            //    entity.HasKey(e => e.IdPersona)
            //        .HasName("PK__Personas__A4788141C915B3DE");

            //    entity.Property(e => e.IdPersona).HasColumnName("idPersona");

            //    entity.Property(e => e.Direccion)
            //        .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .HasColumnName("direccion");

            //    entity.Property(e => e.Edad).HasColumnName("edad");

            //    entity.Property(e => e.FechaCreacion)
            //        .HasColumnType("datetime")
            //        .HasColumnName("fechaCreacion");

            //    entity.Property(e => e.FechaModificacion)
            //        .HasColumnType("datetime")
            //        .HasColumnName("fechaModificacion");

            //    entity.Property(e => e.Genero)
            //        .IsRequired()
            //        .HasMaxLength(1)
            //        .IsUnicode(false)
            //        .HasColumnName("genero")
            //        .IsFixedLength(true);

            //    entity.Property(e => e.Identificacion)
            //        .IsRequired()
            //        .HasMaxLength(15)
            //        .IsUnicode(false)
            //        .HasColumnName("identificacion");

            //    entity.Property(e => e.Nombre)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("nombre");

            //    entity.Property(e => e.Telefono)
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .HasColumnName("telefono");
            //});

            #endregion
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
