using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data.Models
{
    public partial class scazContext : DbContext
    {
        public scazContext()
        {
        }

        public scazContext(DbContextOptions<scazContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudadano> Ciudadanos { get; set; }
        public virtual DbSet<Cuota> Cuotas { get; set; }
        public virtual DbSet<Cuotasciudadano> Cuotasciudadanos { get; set; }
        public virtual DbSet<Nivel> Nivels { get; set; }
        public virtual DbSet<Ocupacione> Ocupaciones { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=1234;database=scaz", ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<Ciudadano>(entity =>
            {
                entity.HasKey(e => e.Clave)
                    .HasName("PRIMARY");

                entity.ToTable("ciudadanos");

                entity.HasIndex(e => e.Curp, "curp_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Ocupacion, "fk_ciudadanos_ocupaciones1_idx");

                entity.Property(e => e.Clave)
                    .HasColumnType("bigint(20)")
                    .ValueGeneratedNever()
                    .HasColumnName("clave");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(80)
                    .HasColumnName("apellidoMaterno");

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(80)
                    .HasColumnName("apellidoPaterno");

                entity.Property(e => e.Comentarios)
                    .HasColumnType("text")
                    .HasColumnName("comentarios");

                entity.Property(e => e.Curp)
                    .HasMaxLength(18)
                    .HasColumnName("curp");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("direccion");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("fechaRegistro");

                entity.Property(e => e.Fechanac)
                    .HasColumnType("date")
                    .HasColumnName("fechanac");

                entity.Property(e => e.Manzana)
                    .HasColumnType("int(11)")
                    .HasColumnName("manzana");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("nombre");

                entity.Property(e => e.Ocupacion)
                    .HasColumnType("int(11)")
                    .HasColumnName("ocupacion");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnType("enum('masculino','femenino')")
                    .HasColumnName("sexo");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("status");

                entity.HasOne(d => d.OcupacionNavigation)
                    .WithMany(p => p.Ciudadanos)
                    .HasForeignKey(d => d.Ocupacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ciudadanos_ocupaciones1");
            });

            modelBuilder.Entity<Cuota>(entity =>
            {
                entity.HasKey(e => e.Folio)
                    .HasName("PRIMARY");

                entity.ToTable("cuotas");

                entity.Property(e => e.Folio)
                    .HasColumnType("int(11)")
                    .HasColumnName("folio");

                entity.Property(e => e.Concepto)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("concepto");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Hora)
                    .HasColumnType("time")
                    .HasColumnName("hora");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('completa','incompleta')")
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Cuotasciudadano>(entity =>
            {
                entity.ToTable("cuotasciudadano");

                entity.HasIndex(e => e.Folio, "fk_cuotas_has_ciudadanos_cuotas1_idx");

                entity.HasIndex(e => e.Ciudadano, "fk_cuotasciudadano_ciudadanos1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Apoyo)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("apoyo");

                entity.Property(e => e.Ciudadano)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("ciudadano");

                entity.Property(e => e.Comentarios)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("comentarios");

                entity.Property(e => e.Descuento).HasColumnName("descuento");

                entity.Property(e => e.Folio)
                    .HasColumnType("int(11)")
                    .HasColumnName("folio");

                entity.Property(e => e.Saldo).HasColumnName("saldo");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("status");

                entity.HasOne(d => d.CiudadanoNavigation)
                    .WithMany(p => p.Cuotasciudadanos)
                    .HasForeignKey(d => d.Ciudadano)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_cuotasciudadano_ciudadanos1");

                entity.HasOne(d => d.FolioNavigation)
                    .WithMany(p => p.Cuotasciudadanos)
                    .HasForeignKey(d => d.Folio)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_cuotas_has_ciudadanos_cuotas1");
            });

            modelBuilder.Entity<Nivel>(entity =>
            {
                entity.HasKey(e => e.Idnivel)
                    .HasName("PRIMARY");

                entity.ToTable("nivel");

                entity.HasIndex(e => e.Tipo, "tipo_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idnivel)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("idnivel");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Ocupacione>(entity =>
            {
                entity.HasKey(e => e.Idocup)
                    .HasName("PRIMARY");

                entity.ToTable("ocupaciones");

                entity.Property(e => e.Idocup)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("idocup");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Nctrl)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Tipo, "fk_usuarios_nivel_idx");

                entity.HasIndex(e => e.Nombre, "nombre_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Nctrl)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("nctrl");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("password");

                entity.Property(e => e.Tipo)
                    .HasColumnType("int(11)")
                    .HasColumnName("tipo");

                entity.HasOne(d => d.TipoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Tipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuarios_nivel");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
