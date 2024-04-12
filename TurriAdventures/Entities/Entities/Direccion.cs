using System;
using System.Collections.Generic;

namespace TurriAdventures.Entities;

public partial class Direccion
{
    public int IdDireccion { get; set; }

    public string? InformacionDireccion { get; set; }

    public virtual ICollection<Hotel> Hotel { get; set; } = new List<Hotel>();
}
