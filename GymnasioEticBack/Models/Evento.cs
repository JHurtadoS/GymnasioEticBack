using System;
using System.Collections.Generic;

namespace GymnasioEticBack.Models;

public partial class Evento
{
    public int IdEventos { get; set; }

    public string? Nombre { get; set; }

    public string? Fecha { get; set; }

    public string? HoraInicio { get; set; }

    public string? HoraSalida { get; set; }

    public int PersonaId { get; set; }

    public virtual Persona? Persona { get; set; } = null!;
}
