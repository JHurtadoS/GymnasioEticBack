using System;
using System.Collections.Generic;

namespace GymnasioEticBack.Models;

public partial class Evento
{
    public int IdEventos { get; set; }

    public string? Nombre { get; set; }

    public DateTime? Fecha { get; set; }

    public TimeSpan? HoraInicio { get; set; }

    public TimeSpan? HoraSalida { get; set; }

    public int UsuarioIdUsuario { get; set; }

    public virtual Persona UsuarioIdUsuarioNavigation { get; set; } = null!;
}
