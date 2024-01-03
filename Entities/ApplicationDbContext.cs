using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoMedexcard.Areas.Identity.Data;
using System.Reflection.Emit;

namespace ProyectoMedexcard.Entities;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
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
    public virtual DbSet<Provincia> Provincia { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Ciudad>(entity =>
        {
            entity.ToTable("Ciudad");

            entity.HasOne(d => d.idProvinciaNavigation)
                .WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.idProvincia);
        });

        builder.Entity<Cliente>(entity =>
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

        builder.Entity<Empleado>(entity =>
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

        builder.Entity<FichaPlan>(entity =>
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

        builder.Entity<Ficha_ClientePlan>(entity =>
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

        builder.Entity<Persona>(entity =>
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

        builder.Entity<Plan>(entity =>
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
        builder.Entity<SecuenciaFormulario>(entity =>
        {
            entity.HasKey(e => e.Se_Id);

            entity.Property(e => e.Se_Anio)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.Property(e => e.Se_Formulario)
                .HasMaxLength(20)
                .IsUnicode(false);
        });
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<ApplicationUser>().ToTable("Users");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x => x.Nombre).HasMaxLength(256);
        builder.Property(x => x.Apellido).HasMaxLength(256);
        builder.Property(x => x.Origen).HasMaxLength(20);
    }
}