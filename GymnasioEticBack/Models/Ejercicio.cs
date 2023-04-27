using System;
using System.Collections.Generic;

namespace GymnasioEticBack.Models;

public partial class Ejercicio
{
    public int Id { get; set; }

    public string? VideoAsociado { get; set; }

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public double? Ncalorias { get; set; }

    public string? Maquina { get; set; }

    public int? EjercicioIdHerramienta { get; set; }

    public virtual Herramientum? EjercicioIdHerramientaNavigation { get; set; }
}
