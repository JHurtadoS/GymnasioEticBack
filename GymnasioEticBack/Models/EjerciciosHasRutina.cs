using System;
using System.Collections.Generic;

namespace GymnasioEticBack.Models;

public partial class EjerciciosHasRutina
{
    public int RutinaEjercicio { get; set; }

    public int? Repeticiones { get; set; }

    public int? Series { get; set; }

    public int EjerciciosId { get; set; }

    public int RutinaId { get; set; }

    public virtual Herramientum Ejercicios { get; set; } = null!;

    public virtual Rutina Rutina { get; set; } = null!;
}
