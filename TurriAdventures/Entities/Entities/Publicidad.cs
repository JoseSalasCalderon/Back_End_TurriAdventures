using System;
using System.Collections.Generic;

namespace TurriAdventures.Entities;

public partial class Publicidad
{
    public int IdPublicidad { get; set; }

    public string? ImagenFacilidad { get; set; }

    public string? LinkPublicidad { get; set; }

    public virtual ICollection<Hotel> Hotel { get; set; } = new List<Hotel>();
}
