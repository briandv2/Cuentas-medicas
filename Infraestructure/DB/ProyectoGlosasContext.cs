using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.DB;

public partial class ProyectoGlosasContext : DbContext
{
    public ProyectoGlosasContext()
    {
    }

    public ProyectoGlosasContext(DbContextOptions<ProyectoGlosasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autenticacion> Autenticacions { get; set; }

    public virtual DbSet<Cup> Cups { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }


    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Glosa> Glosas { get; set; }

    public virtual DbSet<Ip> Ips { get; set; }

    public virtual DbSet<MotidosDeGlosa> MotidosDeGlosas { get; set; }

    public virtual DbSet<MovimientosFactura> MovimientosFacturas { get; set; }

    public virtual DbSet<Notificacione> Notificaciones { get; set; }

    public virtual DbSet<Reporte> Reportes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autenticacion>(entity =>
        {
            entity.HasKey(e => e.AutenticacionId).HasName("PK__Autentic__3E8C6FA3C416B28A");

            entity.ToTable("Autenticacion");

            entity.Property(e => e.AutenticacionId).HasColumnName("AutenticacionID");
            entity.Property(e => e.FechaUltimoLogin).HasColumnType("datetime");
            entity.Property(e => e.Mfaenabled)
                .HasDefaultValue(false)
                .HasColumnName("MFAEnabled");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Autenticacions)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Autentica__Usuar__440B1D61");
        });

        modelBuilder.Entity<Cup>(entity =>
        {
            entity.HasKey(e => e.Cupsid).HasName("PK__CUPS__64F08E4FEACD558C");

            entity.ToTable("CUPS");

            entity.Property(e => e.Cupsid).HasColumnName("CUPSID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.IddetalleFactura).HasName("PK__DetalleF__EF0E5D9AF23F3FCA");

            entity.Property(e => e.IddetalleFactura).HasColumnName("IDDetalleFactura");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Idcups).HasColumnName("IDCUPS");
            entity.Property(e => e.Idfactura).HasColumnName("IDFactura");
            entity.Property(e => e.Valor).HasColumnType("money");

            entity.HasOne(d => d.IdcupsNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.Idcups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleFa__IDCUP__5629CD9C");

            entity.HasOne(d => d.IdfacturaNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.Idfactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleFa__IDFac__5535A963");
        });


        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__Facturas__5C024805FC67036D");

            entity.HasIndex(e => e.Ipsid, "IDX_Facturas_IPSID");

            entity.HasIndex(e => e.NumeroFactura, "IDX_Facturas_NumeroFactura");

            entity.HasIndex(e => e.NumeroFactura, "UQ__Facturas__CF12F9A697E0B0F4").IsUnique();

            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.EstadoFactura).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Ipsid).HasColumnName("IPSID");
            entity.Property(e => e.NumeroFactura).HasMaxLength(50);
            entity.Property(e => e.NumeroIdentificacionPrestador).HasMaxLength(50);
            entity.Property(e => e.RazonSocial).HasMaxLength(255);
            entity.Property(e => e.TipoIdentificacion).HasMaxLength(50);
            entity.Property(e => e.ValorFactura).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Ips).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.Ipsid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Facturas__IPSID__5165187F");
        });

        modelBuilder.Entity<Glosa>(entity =>
        {
            entity.HasKey(e => e.GlosaId).HasName("PK__Glosas__6085E2A8ECB11A42");

            entity.HasIndex(e => e.IddetalleFactura, "IDX_Glosas_FacturaID");

            entity.HasIndex(e => e.NumeroGlosa, "IDX_Glosas_NumeroGlosa");

            entity.HasIndex(e => e.NumeroRadicacion, "IDX_Glosas_NumeroRadicacion");

            entity.HasIndex(e => e.NumeroRadicacion, "UQ__Glosas__077EF7B4C4C96668").IsUnique();

            entity.HasIndex(e => e.NumeroGlosa, "UQ__Glosas__4E5685C1D7071665").IsUnique();

            entity.Property(e => e.GlosaId).HasColumnName("GlosaID");
            entity.Property(e => e.EstadoGlosa)
                .HasMaxLength(50)
                .HasDefaultValue("Generada");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdMotivoGlosa).HasColumnName("idMotivoGlosa");
            entity.Property(e => e.IddetalleFactura).HasColumnName("IDDetalleFactura");
            entity.Property(e => e.MotivoGlosa).HasMaxLength(255);
            entity.Property(e => e.NumeroGlosa).HasMaxLength(50);
            entity.Property(e => e.NumeroRadicacion).HasMaxLength(50);
            entity.Property(e => e.Oficina).HasMaxLength(100);
            entity.Property(e => e.TipoDetalle).HasMaxLength(100);
            entity.Property(e => e.ValorGlosa).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ValorNetoCuenta).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdMotivoGlosaNavigation).WithMany(p => p.Glosas)
                .HasForeignKey(d => d.IdMotivoGlosa)
                .HasConstraintName("FK_Glosas_MotidosDeGlosa");

            entity.HasOne(d => d.IddetalleFacturaNavigation).WithMany(p => p.Glosas)
                .HasForeignKey(d => d.IddetalleFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Glosas__IDDetall__5CD6CB2B");
        });

        modelBuilder.Entity<Ip>(entity =>
        {
            entity.HasKey(e => e.Ipsid).HasName("PK__IPS__690AB3FCA610BB01");

            entity.ToTable("IPS");

            entity.HasIndex(e => e.Nit, "UQ__IPS__C7DEC3C2C603FC53").IsUnique();

            entity.Property(e => e.Ipsid).HasColumnName("IPSID");
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nit)
                .HasMaxLength(20)
                .HasColumnName("NIT");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<MotidosDeGlosa>(entity =>
        {
            entity.HasKey(e => e.IdmotivoGlosa);

            entity.ToTable("MotidosDeGlosa");

            entity.HasIndex(e => e.IdmotivoGlosa, "UQ_MotidosDeGlosa").IsUnique();

            entity.Property(e => e.IdmotivoGlosa)
                .ValueGeneratedNever()
                .HasColumnName("IDMotivoGlosa");
            entity.Property(e => e.Nombre).IsUnicode(false);
        });

        modelBuilder.Entity<MovimientosFactura>(entity =>
        {
            entity.HasKey(e => e.MovimientoId).HasName("PK__Movimien__BF923FCC5FC1603F");

            entity.HasIndex(e => e.FacturaId, "IDX_MovimientosFacturas_FacturaID");

            entity.Property(e => e.MovimientoId).HasColumnName("MovimientoID");
            entity.Property(e => e.DescripcionMovimiento).HasMaxLength(255);
            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.FechaMovimiento)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Factura).WithMany(p => p.MovimientosFacturas)
                .HasForeignKey(d => d.FacturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movimient__Factu__60A75C0F");
        });

        modelBuilder.Entity<Notificacione>(entity =>
        {
            entity.HasKey(e => e.NotificacionId).HasName("PK__Notifica__BCC120C496D3B65C");

            entity.HasIndex(e => e.GlosaId, "IDX_Notificaciones_GlosaID");

            entity.HasIndex(e => e.UsuarioId, "IDX_Notificaciones_UsuarioID");

            entity.Property(e => e.NotificacionId).HasColumnName("NotificacionID");
            entity.Property(e => e.Estado).HasDefaultValue(false);
            entity.Property(e => e.FechaNotificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GlosaId).HasColumnName("GlosaID");
            entity.Property(e => e.Mensaje).HasMaxLength(500);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Glosa).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.GlosaId)
                .HasConstraintName("FK__Notificac__Glosa__6A30C649");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificac__Usuar__693CA210");
        });

        modelBuilder.Entity<Reporte>(entity =>
        {
            entity.HasKey(e => e.ReporteId).HasName("PK__Reportes__0B29EA4EDB54B6CE");

            entity.Property(e => e.ReporteId).HasColumnName("ReporteID");
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.FechaGeneracion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreReporte).HasMaxLength(255);
            entity.Property(e => e.RutaReporte).HasMaxLength(255);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302D1F34F6BDC");

            entity.HasIndex(e => e.NombreRol, "UQ__Roles__4F0B537FA0BE36D4").IsUnique();

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.NombreRol).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE79817054B6D");

            entity.HasIndex(e => e.CorreoElectronico, "IDX_Usuarios_CorreoElectronico");

            entity.HasIndex(e => e.CorreoElectronico, "UQ__Usuarios__531402F3C0E19FD5").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nit)
                .HasMaxLength(20)
                .HasColumnName("NIT");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.TipoUsuario).HasMaxLength(50);

            entity.HasMany(d => d.Rols).WithMany(p => p.Usuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuariosRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Usuarios___RolID__403A8C7D"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Usuarios___Usuar__3F466844"),
                    j =>
                    {
                        j.HasKey("UsuarioId", "RolId").HasName("PK__Usuarios__24AFD7B54C2131AE");
                        j.ToTable("Usuarios_Roles");
                        j.IndexerProperty<int>("UsuarioId").HasColumnName("UsuarioID");
                        j.IndexerProperty<int>("RolId").HasColumnName("RolID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
