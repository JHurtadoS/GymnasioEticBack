using System;
using System.Collections.Generic;

namespace GymnasioEticBack.Models;

public partial class Asistencium
{
    public int IdCita { get; set; }

    public DateTime? FechaHora { get; set; }

    public int UsuarioIdUsuario { get; set; }

    public virtual Persona UsuarioIdUsuarioNavigation { get; set; } = null!;
}
