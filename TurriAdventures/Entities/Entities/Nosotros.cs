using System;
using System.Collections.Generic;

namespace TurriAdventures.Entities;

public partial class Nosotros
{
    public int IdNosotros { get; set; }

    public string? DescripcionNosotros { get; set; }

    public string? ImagenNosotros { get; set; }

    public virtual ICollection<Hotel> Hotel { get; set; } = new List<Hotel>();
}
