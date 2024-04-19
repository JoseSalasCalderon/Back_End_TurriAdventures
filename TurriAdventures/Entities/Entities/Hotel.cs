using Entities.Entities;
using System;
using System.Collections.Generic;

namespace TurriAdventures.Entities;

public partial class Hotel
{
    public int IdHotel { get; set; }

    public string? NombreHotel { get; set; }

    public string? DescripcionHotel { get; set; }

    public string? ImagenBienvenido { get; set; }

    public int? IdContacto { get; set; }

    public int? IdTipoHabitacion { get; set; }

    public int? IdNosotros { get; set; }

    public int? IdDireccion { get; set; }

    public int? IdFacilidad { get; set; }

    public int? IdPublicidad { get; set; }

    public virtual Contacto? IdContactoNavigation { get; set; }

    public virtual Direccion? IdDireccionNavigation { get; set; }

    public virtual Facilidad? IdFacilidadNavigation { get; set; }

    public virtual Nosotros? IdNosotrosNavigation { get; set; }

    public virtual Publicidad? IdPublicidadNavigation { get; set; }

    public virtual TipoHabitacion? IdTipoHabitacionNavigation { get; set; }
}
