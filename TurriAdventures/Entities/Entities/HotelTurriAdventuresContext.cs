using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

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

    public virtual DbSet<Home> Home { get; set; }

    public virtual DbSet<Nosotros> Nosotros { get; set; }

    public virtual DbSet<Oferta> Oferta { get; set; }

    public virtual DbSet<Publicidad> Publicidad { get; set; }

    public virtual DbSet<Reservacion> Reservacion { get; set; }

    public virtual DbSet<Temporada> Temporada { get; set; }

    public virtual DbSet<TipoHabitacion> TipoHabitacion { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    // => optionsBuilder.UseSqlServer("Data Source=DESKTOP-HAJJ5O1;User Id=sa;Password=12345;Initial Catalog=Hotel_Turri_Adventures;TrustServerCertificate=true;");
    //=> optionsBuilder.UseSqlServer("Data Source=LAPTOP-I7JHR1PM;User Id=sa;Password=dylan2604;Initial Catalog=Hotel_Turri_Adventures;TrustServerCertificate=true;");
    => optionsBuilder.UseSqlServer("Data Source=Maria\\SQLEXPRESS;User Id=sa;Password=12345;Initial Catalog=Hotel_Turri_Adventures;TrustServerCertificate=true;");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.IdAdministrador).HasName("PK__Administ__EBE80EA14FB527B1");

            entity.HasIndex(e => e.Usuario, "UQ__Administ__9AFF8FC6420FBF1E").IsUnique();

            entity.Property(e => e.IdAdministrador).HasColumnName("idAdministrador");
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
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EE0554A9B6");

            entity.Property(e => e.IdCliente)
                .HasMaxLength(8)
                .IsUnicode(false)
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
            entity.HasKey(e => e.IdContacto).HasName("PK__Contacto__4B1329C7320A0519");

            entity.Property(e => e.IdContacto).HasColumnName("idContacto");
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
            entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__B49878C90F893EC8");

            entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");
            entity.Property(e => e.InformacionDireccion).HasColumnName("informacionDireccion");
        });

        modelBuilder.Entity<Facilidad>(entity =>
        {
            entity.HasKey(e => e.IdFacilidad).HasName("PK__Facilida__B29C0B01EF847B2B");

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
            entity.HasKey(e => e.IdHabitacion).HasName("PK__Habitaci__D9D53BE2208C9833");

            entity.Property(e => e.IdHabitacion).HasColumnName("idHabitacion");
            entity.Property(e => e.CapacidadMaxima).HasColumnName("capacidadMaxima");
            entity.Property(e => e.EstadoHabitacion).HasColumnName("estadoHabitacion");
            entity.Property(e => e.IdTipoHabitacion).HasColumnName("idTipoHabitacion");
            entity.Property(e => e.NumeroHabitacion).HasColumnName("numeroHabitacion");

            entity.HasOne(d => d.IdTipoHabitacionNavigation).WithMany(p => p.Habitacion)
                .HasForeignKey(d => d.IdTipoHabitacion)
                .HasConstraintName("FK__Habitacio__idTip__38996AB5");
        });

        modelBuilder.Entity<Home>(entity =>
        {
            entity.HasKey(e => e.IdHome).HasName("PK__Home__77045CBFE46C92A5");

            entity.Property(e => e.IdHome).HasColumnName("idHome");
            entity.Property(e => e.DescripcionHome).HasColumnName("descripcionHome");
            entity.Property(e => e.ImagenHome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagenHome");
        });

        modelBuilder.Entity<Nosotros>(entity =>
        {
            entity.HasKey(e => e.IdNosotros).HasName("PK__Nosotros__703F9C8D18A7B3E1");

            entity.Property(e => e.IdNosotros).HasColumnName("idNosotros");
            entity.Property(e => e.DescripcionNosotros).HasColumnName("descripcion");
            entity.Property(e => e.ImagenNosotros)
                .IsUnicode(false)
                .HasColumnName("imagenNosotros");
        });

        modelBuilder.Entity<Oferta>(entity =>
        {
            entity.HasKey(e => e.IdOferta).HasName("PK__Oferta__05A1245EB2E8D14E");

            entity.Property(e => e.IdOferta).HasColumnName("idOferta");
            entity.Property(e => e.Activo).HasColumnName("activo");
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
            entity.HasKey(e => e.IdPublicidad).HasName("PK__Publicid__3F75C48209E1362C");

            entity.Property(e => e.IdPublicidad).HasColumnName("idPublicidad");
            entity.Property(e => e.ImagenPublicidad)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagenPublicidad");
            entity.Property(e => e.LinkPublicidad)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("linkPublicidad");
            entity.Property(e => e.NombrePublicidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombrePublicidad");
        });

        modelBuilder.Entity<Reservacion>(entity =>
        {
            entity.HasKey(e => e.IdReservacion).HasName("PK__Reservac__C813D8AD2D3F3644");

            entity.Property(e => e.IdReservacion).HasColumnName("idReservacion");
            entity.Property(e => e.Activo).HasColumnName("activo");
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
            entity.Property(e => e.IdCliente)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("idCliente");
            entity.Property(e => e.IdHabitacion).HasColumnName("idHabitacion");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Reservacion)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Reservaci__idCli__3C69FB99");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Reservacion)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK__Reservaci__idHab__3B75D760");
        });

        modelBuilder.Entity<Temporada>(entity =>
        {
            entity.HasKey(e => e.IdTemporada).HasName("PK__Temporad__1209DE746D89DFCC");

            entity.Property(e => e.IdTemporada).HasColumnName("idTemporada");
            entity.Property(e => e.Activo).HasColumnName("activo");
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
            entity.HasKey(e => e.IdTipoHabitacion).HasName("PK__TipoHabi__64CD3F692A6D1A75");

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
                .HasConstraintName("FK__TipoHabit__idOfe__32E0915F");

            entity.HasOne(d => d.IdTemporadaNavigation).WithMany(p => p.TipoHabitacion)
                .HasForeignKey(d => d.IdTemporada)
                .HasConstraintName("FK__TipoHabit__idTem__33D4B598");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
