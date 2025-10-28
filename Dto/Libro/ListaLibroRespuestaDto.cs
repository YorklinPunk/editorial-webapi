namespace editorial_webapi.Dto.Libro
{
    public class ListaLibroRespuestaDto
    {
        public int IdLibro { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public string? Genero { get; set; }
        public decimal Precio { get; set; }
        public string? Editorial { get; set; }
        public string? Categoria { get; set; }
        public string? TipoLibro { get; set; }
    }
}
