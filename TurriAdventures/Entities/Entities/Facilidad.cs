using System;
using System.Collections.Generic;

namespace TurriAdventures.Entities;

public partial class Facilidad
{
    public int IdFacilidad { get; set; }

    public string? DescripcionFacilidad { get; set; }

    public string? ImagenFacilidad { get; set; }

    public virtual ICollection<Hotel> Hotel { get; set; } = new List<Hotel>();
}
