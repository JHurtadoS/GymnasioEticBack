using System;
using System.Collections.Generic;

namespace GymnasioEticBack.Models;

public partial class Herramientum
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? ImagenAsociada { get; set; }

    public virtual ICollection<Ejercicio>? Ejercicios { get; } = new List<Ejercicio>();

    public virtual ICollection<EjerciciosHasRutina>? EjerciciosHasRutinas { get; } = new List<EjerciciosHasRutina>();
}
