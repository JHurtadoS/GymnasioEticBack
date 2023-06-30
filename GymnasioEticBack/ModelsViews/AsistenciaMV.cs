using GymnasioEticBack.Models;

namespace GymnasioEticBack.ModelsViews
{
    public class AsistenciaMV
    {
        public int? IdCita { get; set; }

        public string? FechaHora { get; set; }

        public string? PersonaId { get; set; }
        public virtual Persona? Persona { get; set; } = null!;
    }
}
