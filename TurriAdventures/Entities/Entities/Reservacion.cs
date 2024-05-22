using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Reservacion
{
    public int IdReservacion { get; set; }

    public DateTime? FechaLlegada { get; set; }

    public DateTime? FechaSalida { get; set; }

    public string? EstadoReservacion { get; set; }

    public int? IdHabitacion { get; set; }

    public string? IdCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Habitacion? IdHabitacionNavigation { get; set; }
}
