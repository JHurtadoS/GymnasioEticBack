using System;
using System.Collections.Generic;

namespace GymnasioEticBack.Models;

public partial class PersonaHasRutina
{
    public int RutinasPersona { get; set; }

    public int PersonaId { get; set; }

    public int RutinaId { get; set; }

    public virtual Persona Persona { get; set; } = null!;

    public virtual Rutina Rutina { get; set; } = null!;
}
