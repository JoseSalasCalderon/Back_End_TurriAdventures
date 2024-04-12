using System;
using System.Collections.Generic;

namespace TurriAdventures.Entities;

public partial class Administrador
{
    public int IdAdministrador { get; set; }

    public string? Usuario { get; set; }

    public string? Contrasena { get; set; }
}
