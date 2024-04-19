using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TurriAdventures.Entities;

public partial class HotelTurriAdventuresContext : DbContext
{
    public HotelTurriAdventuresContext()
    {
    }

    public HotelTurriAdventuresContext(DbContextOptions<HotelTurriAdventuresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administrador { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Contacto> Contacto { get; set; }

    public virtual DbSet<Direccion> Direccion { get; set; }

    public virtual DbSet<Facilidad> Facilidad { get; set; }

    public virtual DbSet<Habitacion> Habitacion { get; set; }

    public virtual DbSet<Hotel> Hotel { get; set; }

    public virtual DbSet<Nosotros> Nosotros { get; set; }

    public virtual DbSet<Oferta> Oferta { get; set; }

    public virtual DbSet<Publicidad> Publicidad { get; set; }

    public virtual DbSet<Reservacion> Reservacion { get; set; }

    public virtual DbSet<Temporada> Temporada { get; set; }

    public virtual DbSet<TipoHabitacion> TipoHabitacion { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-HAJJ5O1;User Id=sa;Password=12345;Initial Catalog=Hotel_Turri_Adventures;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.IdAdministrador).HasName("PK__Administ__EBE80EA175E21F90");

            entity.Property(e => e.IdAdministrador)
                .ValueGeneratedNever()
                .HasColumnName("idAdministrador");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EEF9E691EE");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("idCliente");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.IdContacto).HasName("PK__Contacto__4B1329C7BF264E66");

            entity.Property(e => e.IdContacto)
                .ValueGeneratedNever()
                .HasColumnName("idContacto");
            entity.Property(e => e.ApartadoPostal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apartadoPostal");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Telefono1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono1");
            entity.Property(e => e.Telefono2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono2");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__B49878C96EF703A2");

            entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");
            entity.Property(e => e.InformacionDireccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("informacionDireccion");
        });

        modelBuilder.Entity<Facilidad>(entity =>
        {
            entity.HasKey(e => e.IdFacilidad).HasName("PK__Facilida__B29C0B0127601DB3");

            entity.Property(e => e.IdFacilidad).HasColumnName("idFacilidad");
            entity.Property(e => e.DescripcionFacilidad)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcionFacilidad");
            entity.Property(e => e.ImagenFacilidad)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagenFacilidad");
        });

        modelBuilder.Entity<Habitacion>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__Habitaci__D9D53BE2B01F6CA6");

            entity.Property(e => e.IdHabitacion).HasColumnName("idHabitacion");
            entity.Property(e => e.CapacidadMaxima).HasColumnName("capacidadMaxima");
            entity.Property(e => e.EstadoHabitacion).HasColumnName("estadoHabitacion");
            entity.Property(e => e.IdTipoHabitacion).HasColumnName("idTipoHabitacion");
            entity.Property(e => e.NumeroHabitacion).HasColumnName("numeroHabitacion");

            entity.HasOne(d => d.IdTipoHabitacionNavigation).WithMany(p => p.Habitacion)
                .HasForeignKey(d => d.IdTipoHabitacion)
                .HasConstraintName("FK__Habitacio__idTip__35BCFE0A");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.IdHotel).HasName("PK__Hotel__AE924C1CACBF7651");

            entity.Property(e => e.IdHotel).HasColumnName("idHotel");
            entity.Property(e => e.DescripcionHotel)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcionHotel");
            entity.Property(e => e.IdContacto).HasColumnName("idContacto");
            entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");
            entity.Property(e => e.IdFacilidad).HasColumnName("idFacilidad");
            entity.Property(e => e.IdNosotros).HasColumnName("idNosotros");
            entity.Property(e => e.IdPublicidad).HasColumnName("idPublicidad");
            entity.Property(e => e.IdTipoHabitacion).HasColumnName("idTipoHabitacion");
            entity.Property(e => e.ImagenBienvenido)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagenBienvenido");
            entity.Property(e => e.NombreHotel)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombreHotel");

            entity.HasOne(d => d.IdContactoNavigation).WithMany(p => p.Hotel)
                .HasForeignKey(d => d.IdContacto)
                .HasConstraintName("FK__Hotel__idContact__3E52440B");

            entity.HasOne(d => d.IdDireccionNavigation).WithMany(p => p.Hotel)
                .HasForeignKey(d => d.IdDireccion)
                .HasConstraintName("FK__Hotel__idDirecci__412EB0B6");

            entity.HasOne(d => d.IdFacilidadNavigation).WithMany(p => p.Hotel)
                .HasForeignKey(d => d.IdFacilidad)
                .HasConstraintName("FK__Hotel__idFacilid__4222D4EF");

            entity.HasOne(d => d.IdNosotrosNavigation).WithMany(p => p.Hotel)
                .HasForeignKey(d => d.IdNosotros)
                .HasConstraintName("FK__Hotel__idNosotro__403A8C7D");

            entity.HasOne(d => d.IdPublicidadNavigation).WithMany(p => p.Hotel)
                .HasForeignKey(d => d.IdPublicidad)
                .HasConstraintName("FK__Hotel__idPublici__4316F928");

            entity.HasOne(d => d.IdTipoHabitacionNavigation).WithMany(p => p.Hotel)
                .HasForeignKey(d => d.IdTipoHabitacion)
                .HasConstraintName("FK__Hotel__idTipoHab__3F466844");
        });

        modelBuilder.Entity<Nosotros>(entity =>
        {
            entity.HasKey(e => e.IdNosotros).HasName("PK__Nosotros__703F9C8D1AFB3E61");

            entity.Property(e => e.IdNosotros).HasColumnName("idNosotros");
            entity.Property(e => e.DescripcionNosotros)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcionNosotros");
            entity.Property(e => e.ImagenNosotros)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagenNosotros");
        });

        modelBuilder.Entity<Oferta>(entity =>
        {
            entity.HasKey(e => e.IdOferta).HasName("PK__Oferta__05A1245E5B78D378");

            entity.Property(e => e.IdOferta).HasColumnName("idOferta");
            entity.Property(e => e.DescripcionOferta)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcionOferta");
            entity.Property(e => e.FechaFinalOferta)
                .HasColumnType("datetime")
                .HasColumnName("fechaFinalOferta");
            entity.Property(e => e.FechaInicioOferta)
                .HasColumnType("datetime")
                .HasColumnName("fechaInicioOferta");
            entity.Property(e => e.PrecioOferta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precioOferta");
        });

        modelBuilder.Entity<Publicidad>(entity =>
        {
            entity.HasKey(e => e.IdPublicidad).HasName("PK__Publicid__3F75C482E6DF3E3C");

            entity.Property(e => e.IdPublicidad).HasColumnName("idPublicidad");
            entity.Property(e => e.ImagenFacilidad)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagenFacilidad");
            entity.Property(e => e.LinkPublicidad)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("linkPublicidad");
        });

        modelBuilder.Entity<Reservacion>(entity =>
        {
            entity.HasKey(e => e.IdReservacion).HasName("PK__Reservac__C813D8AD0689E394");

            entity.Property(e => e.IdReservacion).HasColumnName("idReservacion");
            entity.Property(e => e.EstadoReservacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estadoReservacion");
            entity.Property(e => e.FechaLlegada)
                .HasColumnType("datetime")
                .HasColumnName("fechaLlegada");
            entity.Property(e => e.FechaSalida)
                .HasColumnType("datetime")
                .HasColumnName("fechaSalida");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdHabitacion).HasColumnName("idHabitacion");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Reservacion)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Reservaci__idCli__398D8EEE");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Reservacion)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK__Reservaci__idHab__38996AB5");
        });

        modelBuilder.Entity<Temporada>(entity =>
        {
            entity.HasKey(e => e.IdTemporada).HasName("PK__Temporad__1209DE74574E3DAA");

            entity.Property(e => e.IdTemporada).HasColumnName("idTemporada");
            entity.Property(e => e.DescripcionTemporada)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcionTemporada");
            entity.Property(e => e.FechaFinalTemporada)
                .HasColumnType("datetime")
                .HasColumnName("fechaFinalTemporada");
            entity.Property(e => e.FechaInicioTemporada)
                .HasColumnType("datetime")
                .HasColumnName("fechaInicioTemporada");
            entity.Property(e => e.PrecioTemporada)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precioTemporada");
        });

        modelBuilder.Entity<TipoHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoHabitacion).HasName("PK__TipoHabi__64CD3F697F740766");

            entity.Property(e => e.IdTipoHabitacion).HasColumnName("idTipoHabitacion");
            entity.Property(e => e.DescripcionTipoHabitacion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcionTipoHabitacion");
            entity.Property(e => e.IdOferta).HasColumnName("idOferta");
            entity.Property(e => e.IdTemporada).HasColumnName("idTemporada");
            entity.Property(e => e.ImagenTipoHabitacion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagenTipoHabitacion");
            entity.Property(e => e.NombreTipoHabitacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreTipoHabitacion");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.IdOfertaNavigation).WithMany(p => p.TipoHabitacion)
                .HasForeignKey(d => d.IdOferta)
                .HasConstraintName("FK__TipoHabit__idOfe__300424B4");

            entity.HasOne(d => d.IdTemporadaNavigation).WithMany(p => p.TipoHabitacion)
                .HasForeignKey(d => d.IdTemporada)
                .HasConstraintName("FK__TipoHabit__idTem__30F848ED");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
