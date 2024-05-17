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

    public virtual DbSet<Direccion> Direccion { get; set; }

    public virtual DbSet<Facilidad> Facilidad { get; set; }

    public virtual DbSet<Habitacion> Habitacion { get; set; }

    public virtual DbSet<Nosotros> Nosotros { get; set; }

    public virtual DbSet<Oferta> Oferta { get; set; }

    public virtual DbSet<Publicidad> Publicidad { get; set; }

    public virtual DbSet<Reservacion> Reservacion { get; set; }

    public virtual DbSet<Temporada> Temporada { get; set; }

    public virtual DbSet<TipoHabitacion> TipoHabitacion { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-I7JHR1PM;User Id=sa;Password=dylan2604;Initial Catalog=Hotel_Turri_Adventures;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.IdAdministrador).HasName("PK__Administ__EBE80EA14D02757E");

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
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EE0C27D35F");

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

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__B49878C9E01F0487");

            entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");
            entity.Property(e => e.InformacionDireccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("informacionDireccion");
        });

        modelBuilder.Entity<Facilidad>(entity =>
        {
            entity.HasKey(e => e.IdFacilidad).HasName("PK__Facilida__B29C0B01AD37A89E");

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
            entity.HasKey(e => e.IdHabitacion).HasName("PK__Habitaci__D9D53BE2966A794A");

            entity.Property(e => e.IdHabitacion).HasColumnName("idHabitacion");
            entity.Property(e => e.CapacidadMaxima).HasColumnName("capacidadMaxima");
            entity.Property(e => e.EstadoHabitacion).HasColumnName("estadoHabitacion");
            entity.Property(e => e.IdTipoHabitacion).HasColumnName("idTipoHabitacion");
            entity.Property(e => e.NumeroHabitacion).HasColumnName("numeroHabitacion");

            entity.HasOne(d => d.IdTipoHabitacionNavigation).WithMany(p => p.Habitacion)
                .HasForeignKey(d => d.IdTipoHabitacion)
                .HasConstraintName("FK__Habitacio__idTip__4AB81AF0");
        });

        modelBuilder.Entity<Nosotros>(entity =>
        {
            entity.HasKey(e => e.IdNosotros).HasName("PK__Nosotros__703F9C8D7D772195");

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
            entity.HasKey(e => e.IdOferta).HasName("PK__Oferta__05A1245E115884CC");

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
            entity.HasKey(e => e.IdPublicidad).HasName("PK__Publicid__3F75C482A0EC4658");

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
            entity.HasKey(e => e.IdReservacion).HasName("PK__Reservac__C813D8ADE48763BE");

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
            entity.Property(e => e.IdCliente)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("idCliente");
            entity.Property(e => e.IdHabitacion).HasColumnName("idHabitacion");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Reservacion)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Reservaci__idCli__5224328E");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Reservacion)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK__Reservaci__idHab__51300E55");
        });

        modelBuilder.Entity<Temporada>(entity =>
        {
            entity.HasKey(e => e.IdTemporada).HasName("PK__Temporad__1209DE740C5789E3");

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
            entity.HasKey(e => e.IdTipoHabitacion).HasName("PK__TipoHabi__64CD3F69FE89358D");

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
                .HasConstraintName("FK__TipoHabit__idOfe__44FF419A");

            entity.HasOne(d => d.IdTemporadaNavigation).WithMany(p => p.TipoHabitacion)
                .HasForeignKey(d => d.IdTemporada)
                .HasConstraintName("FK__TipoHabit__idTem__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
