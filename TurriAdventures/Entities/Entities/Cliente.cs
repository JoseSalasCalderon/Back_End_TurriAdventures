using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Cliente
{
    public string IdCliente { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Reservacion> Reservacions { get; set; } = new List<Reservacion>();
}
