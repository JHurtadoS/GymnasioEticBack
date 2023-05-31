﻿using System;
using System.Collections.Generic;

namespace GymnasioEticBack.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Correo { get; set; }

    public string? Contraseña { get; set; }

    public virtual ICollection<Persona>? Personas { get; } = new List<Persona>();
}
