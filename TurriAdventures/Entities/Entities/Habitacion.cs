using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Habitacion
{
    public int IdHabitacion { get; set; }

    public int? EstadoHabitacion { get; set; }

    public int? NumeroHabitacion { get; set; }

    public int? CapacidadMaxima { get; set; }

    public int? IdTipoHabitacion { get; set; }

    public virtual TipoHabitacion? IdTipoHabitacionNavigation { get; set; }

    public virtual ICollection<Reservacion> Reservacion { get; set; } = new List<Reservacion>();
}
