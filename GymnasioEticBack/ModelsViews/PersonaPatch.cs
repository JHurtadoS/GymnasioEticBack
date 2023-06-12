namespace GymnasioEticBack.ModelsViews
{
    public class PersonaPatch
    {
        public int? ID { get; set; }

        public int? Documento { get; set; }

        public string? Nombre { get; set; }

        public string? Apellidos { get; set; }

        public long? Celular { get; set; }

        public string? Genero { get; set; }

        public string? Rh { get; set; }

        public string? Rol { get; set; }

        public bool? Desahabilitado { get; set; }
    }
}
