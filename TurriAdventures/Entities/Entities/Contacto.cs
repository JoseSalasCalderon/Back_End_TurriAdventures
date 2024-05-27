using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Contacto
{
    public int IdContacto { get; set; }

    public string? Telefono1 { get; set; }

    public string? Telefono2 { get; set; }

    public string? ApartadoPostal { get; set; }

    public string? Email { get; set; }
}
