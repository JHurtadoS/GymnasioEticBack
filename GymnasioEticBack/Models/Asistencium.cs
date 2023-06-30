using System;
using System.Collections.Generic;

namespace GymnasioEticBack.Models;

public partial class Asistencium
{
    public int IdCita { get; set; }

    public string? FechaHora { get; set; }

    public int PersonaId { get; set; }

    public virtual Persona? Persona { get; set; } = null!;
}
