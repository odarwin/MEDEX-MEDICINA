using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoMedexcard.Entities
{
    public partial class ProyectoMedexcardContext : DbContext
    {
        public ProyectoMedexcardContext()
        {
        }

        public ProyectoMedexcardContext(DbContextOptions<ProyectoMedexcardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudads { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<FichaPlan> FichaPlans { get; set; } = null!;
        public virtual DbSet<Ficha_ClientePlan> Ficha_ClientePlans { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Plan> Plans { get; set; } = null!;
        public virtual DbSet<Provincium> Provincia { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoleClaim> RoleClaims { get; set; } = null!;
        public virtual DbSet<SecuenciaFormulario> SecuenciaFormularios { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserClaim> UserClaims { get; set; } = null!;
        public virtual DbSet<UserLogin> UserLogins { get; set; } = null!;
        public virtual DbSet<UserToken> UserTokens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=ProyectoMedexcard;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.ToTable("Ciudad");

                entity.HasOne(d => d.idProvinciaNavigation)
                    .WithMany(p => p.Ciudads)
                    .HasForeignKey(d => d.idProvincia);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Cl_Id);

                entity.ToTable("Cliente");

                entity.Property(e => e.Cl_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Cl_FechaElimina).HasColumnType("datetime");

                entity.Property(e => e.Cl_FechaModifica).HasColumnType("datetime");

                entity.HasOne(d => d.Cl_IdPersonaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Cl_IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Persona");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.Em_Id);

                entity.ToTable("Empleado");

                entity.Property(e => e.Em_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Em_FechaElimina).HasColumnType("datetime");

                entity.Property(e => e.Em_FechaModifica).HasColumnType("datetime");

                entity.Property(e => e.Em_Rol)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Em_IdPersonaNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.Em_IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Empleado_Persona_FK");
            });

            modelBuilder.Entity<FichaPlan>(entity =>
            {
                entity.HasKey(e => e.Fp_Id);

                entity.ToTable("FichaPlan");

                entity.Property(e => e.Fp_Fecha).HasColumnType("datetime");

                entity.Property(e => e.Fp_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Fp_FechaElimina).HasColumnType("datetime");

                entity.Property(e => e.Fp_FechaModifica).HasColumnType("datetime");

                entity.Property(e => e.Fp_Secuencia)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Fp_IdCiudadNavigation)
                    .WithMany(p => p.FichaPlans)
                    .HasForeignKey(d => d.Fp_IdCiudad)
                    .HasConstraintName("FK_Plan_Ciudad");

                entity.HasOne(d => d.Fp_IdEmpleadoNavigation)
                    .WithMany(p => p.FichaPlans)
                    .HasForeignKey(d => d.Fp_IdEmpleado)
                    .HasConstraintName("FK_Empleado_Plan");

                entity.HasOne(d => d.Fp_IdPlanNavigation)
                    .WithMany(p => p.FichaPlans)
                    .HasForeignKey(d => d.Fp_IdPlan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plan_PlanFicha");
            });

            modelBuilder.Entity<Ficha_ClientePlan>(entity =>
            {
                entity.HasKey(e => e.Fcp_Id);

                entity.ToTable("Ficha_ClientePlan");

                entity.Property(e => e.Fcp_Cedula)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fcp_Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fcp_DirDomicilio)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Fcp_DirLaboral)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Fcp_Estado)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fcp_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Fcp_FechaElimina).HasColumnType("datetime");

                entity.Property(e => e.Fcp_FechaModifica).HasColumnType("datetime");

                entity.Property(e => e.Fcp_Secuencia)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fcp_Telefono1)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fcp_Telefono2)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fcp_ValorLetrasPlan).HasColumnType("money");

                entity.Property(e => e.Fcp_ValorPlan).HasColumnType("money");

                entity.HasOne(d => d.Fcp_IdClienteNavigation)
                    .WithMany(p => p.Ficha_ClientePlans)
                    .HasForeignKey(d => d.Fcp_IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Ficha");

                entity.HasOne(d => d.Fcp_IdPlanNavigation)
                    .WithMany(p => p.Ficha_ClientePlans)
                    .HasForeignKey(d => d.Fcp_IdPlan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_plan_idplan");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Per_Id);

                entity.ToTable("Persona");

                entity.Property(e => e.Per_Apellido)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Per_Cedula)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Per_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Per_FechaElimina).HasColumnType("datetime");

                entity.Property(e => e.Per_FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Per_Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Per_NombreCompleto)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Per_Pasaporte)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Per_Ruc)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Per_TipoIdentificacion)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.pl_id);

                entity.ToTable("Plan");

                entity.Property(e => e.pl_codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.pl_descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.pl_fecha_creacion).HasColumnType("datetime");

                entity.Property(e => e.pl_fecha_elimina).HasColumnType("datetime");

                entity.Property(e => e.pl_fecha_modificacion).HasColumnType("datetime");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<RoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<SecuenciaFormulario>(entity =>
            {
                entity.HasKey(e => e.Se_Id);

                entity.Property(e => e.Se_Anio)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Se_Formulario)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Apellido).HasMaxLength(256);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Nombre).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.Origen).HasMaxLength(20);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PK_AspNetUserRoles");

                            j.ToTable("UserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<UserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PK_AspNetUserLogins");

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PK_AspNetUserTokens");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
