using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class TipoHabitacion
{
    public int IdTipoHabitacion { get; set; }

    public string? NombreTipoHabitacion { get; set; }

    public decimal? Precio { get; set; }

    public string? DescripcionTipoHabitacion { get; set; }

    public string? ImagenTipoHabitacion { get; set; }

    public int? IdOferta { get; set; }

    public int? IdTemporada { get; set; }

    public virtual ICollection<Habitacion> Habitacion { get; set; } = new List<Habitacion>();

    public virtual Oferta? IdOfertaNavigation { get; set; }

    public virtual Temporada? IdTemporadaNavigation { get; set; }
}
