namespace editorial_webapi.Dto.Libro
{
    public class DetalleLibroDigitalRespuestaDto
    {
        public int IdLibro { get; set; }
        public string? FormatoArchivo { get; set; }
        public decimal TamanoMB { get; set; }
        public string? UrlDescarga { get; set; }
    }
}
