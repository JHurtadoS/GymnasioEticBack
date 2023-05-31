using System;
using System.Collections.Generic;

namespace GymnasioEticBack.Models;

public partial class Rutina
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? TipRutina { get; set; }

    public virtual ICollection<EjerciciosHasRutina>? EjerciciosHasRutinas { get; } = new List<EjerciciosHasRutina>();

    public virtual ICollection<PersonaHasRutina>? PersonaHasRutinas { get; } = new List<PersonaHasRutina>();
}
