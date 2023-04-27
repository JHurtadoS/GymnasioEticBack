using System;
using System.Collections.Generic;

namespace GymnasioEticBack.Models;

public partial class Persona
{
    public int IdUsuario { get; set; }

    public int PersonaIdUsuario { get; set; }

    public int? Documento { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public long? Celular { get; set; }

    public string? Genero { get; set; }

    public string? Rh { get; set; }

    public string? Rol { get; set; }

    public virtual ICollection<Asistencium> Asistencia { get; } = new List<Asistencium>();

    public virtual ICollection<Evento> Eventos { get; } = new List<Evento>();

    public virtual ICollection<PersonaHasRutina> PersonaHasRutinas { get; } = new List<PersonaHasRutina>();

    public virtual Usuario PersonaIdUsuarioNavigation { get; set; } = null!;
}
