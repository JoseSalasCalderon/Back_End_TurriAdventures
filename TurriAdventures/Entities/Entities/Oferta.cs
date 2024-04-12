using System;
using System.Collections.Generic;

namespace TurriAdventures.Entities;

public partial class Oferta
{
    public int IdOferta { get; set; }

    public string? DescripcionOferta { get; set; }

    public DateTime? FechaInicioOferta { get; set; }

    public DateTime? FechaFinalOferta { get; set; }

    public decimal? PrecioOferta { get; set; }

    public virtual ICollection<TipoHabitacion> TipoHabitacion { get; set; } = new List<TipoHabitacion>();
}
