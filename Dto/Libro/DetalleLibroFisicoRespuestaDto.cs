namespace editorial_webapi.Dto.Libro
{
    public class DetalleLibroFisicoRespuestaDto
    {
        public int IdLibro { get; set; }
        public int Stock { get; set; }
        public string? TipoTapa { get; set; }
        public decimal PesoGramos { get; set; }
    }
}
