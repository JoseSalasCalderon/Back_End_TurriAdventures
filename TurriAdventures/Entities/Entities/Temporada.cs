using System;
using System.Collections.Generic;

namespace TurriAdventures.Entities;

public partial class Temporada
{
    public int IdTemporada { get; set; }

    public string? DescripcionTemporada { get; set; }

    public DateTime? FechaInicioTemporada { get; set; }

    public DateTime? FechaFinalTemporada { get; set; }

    public decimal? PrecioTemporada { get; set; }

    public virtual ICollection<TipoHabitacion> TipoHabitacion { get; set; } = new List<TipoHabitacion>();
}
