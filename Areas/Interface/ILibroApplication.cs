using editorial_webapi.Configurations;
using editorial_webapi.Dto.Libro;

namespace editorial_webapi.Areas.Interface
{
    public interface ILibroApplication
    {
        Task<OperationResult<List<ListaLibroRespuestaDto>>> ListaLibros();
        Task<OperationResult<DetalleLibroDigitalRespuestaDto>> ListaDetalleDigital(int IdLibro);
        Task<OperationResult<DetalleLibroFisicoRespuestaDto>> ListaDetalleFisico(int IdLibro);
        Task<OperationResult<string>> RegistroLibro(RegistroLibroPeticionDto registroLibroPeticionDto);
        Task<OperationResult<string>> RegistroDetalleDigital(DetalleLibroDigitalRespuestaDto detalleLibroDigitalRespuestaDto);
        Task<OperationResult<string>> RegistroDetalleFisico(DetalleLibroFisicoRespuestaDto detalleLibroFisicoRespuestaDto);
        Task<OperationResult<string>> EditarLibro(EditarLibroPeticionDto editarLibroPeticionDto);
    }
}
