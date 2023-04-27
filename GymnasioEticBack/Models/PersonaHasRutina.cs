using System;
using System.Collections.Generic;

namespace GymnasioEticBack.Models;

public partial class PersonaHasRutina
{
    public int RutinasPersona { get; set; }

    public int UsuarioIdUsuario { get; set; }

    public int RutinaId { get; set; }

    public virtual Rutina Rutina { get; set; } = null!;

    public virtual Persona UsuarioIdUsuarioNavigation { get; set; } = null!;
}
