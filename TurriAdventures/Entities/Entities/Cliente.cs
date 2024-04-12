using System;
using System.Collections.Generic;

namespace TurriAdventures.Entities;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Reservacion> Reservacion { get; set; } = new List<Reservacion>();
}
