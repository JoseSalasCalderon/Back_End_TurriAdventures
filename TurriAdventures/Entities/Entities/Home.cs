using System;
using System.Collections.Generic;

namespace TurriAdventures.Entities;

public partial class Home
{
    public int IdHome { get; set; }

    public string? ImagenHome { get; set; }

    public string? DescripcionHome { get; set; }

    //public virtual ICollection<Hotel> Hotel { get; set; } = new List<Hotel>();

}
