namespace editorial_webapi.Dto.Libro
{
    public class EditarLibroPeticionDto
    {
        public int IdLibro { get; set; }
        public string? Titulo { get; set; }
        public string? Genero { get; set; }
        public decimal Precio { get; set; }
        public string? Editorial { get; set; }
        public int IdCategoria { get; set; }
        public int TipoLibro { get; set; }
    }
}
