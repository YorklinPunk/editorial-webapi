using editorial_webapi.Areas.Interface;
using editorial_webapi.Configurations;
using editorial_webapi.Dto.Libro;
using Microsoft.AspNetCore.Mvc;

namespace editorial_webapi.Areas.Controllers
{
    [Route("api/[controller]")]
    public class LibroController : Controller
    {
        private readonly ILibroApplication libroApplication;

        public LibroController(ILibroApplication libroApplication) => this.libroApplication = libroApplication;

        [HttpGet]
        [Route("listaLibros")]
        public async Task<OperationResult<List<ListaLibroRespuestaDto>>> ListaLibros()
        {
            var resultado = await libroApplication.ListaLibros();
            return resultado;
        }

        [HttpGet]
        [Route("listaDetalleLibroDigital")]
        public async Task<OperationResult<DetalleLibroDigitalRespuestaDto>> ListaDetalleDigital(int IdLibro)
        {
            var resultado = await libroApplication.ListaDetalleDigital(IdLibro);
            return resultado;
        }

        [HttpGet]
        [Route("listaDetalleLibroFisico")]
        public async Task<OperationResult<DetalleLibroFisicoRespuestaDto>> ListaDetalleFisico(int IdLibro)
        {
            var resultado = await libroApplication.ListaDetalleFisico(IdLibro);
            return resultado;
        }

        [HttpPost]
        [Route("registroLibro")]
        public async Task<OperationResult<string>> RegistroLibro([FromBody] RegistroLibroPeticionDto registroLibroPeticionDto)
        {
            var resultado = await libroApplication.RegistroLibro(registroLibroPeticionDto);
            return resultado;
        }

        [HttpPut]
        [Route("registroDetalleDigital")]
        public async Task<OperationResult<string>> RegistroDetalleDigital([FromBody] DetalleLibroDigitalRespuestaDto detalleLibroDigitalRespuestaDto)
        {
            var resultado = await libroApplication.RegistroDetalleDigital(detalleLibroDigitalRespuestaDto);
            return resultado;
        }

        [HttpPut]
        [Route("registroDetalleFisico")]
        public async Task<OperationResult<string>> RegistroDetalleFisico([FromBody] DetalleLibroFisicoRespuestaDto detalleLibroFisicoRespuestaDto)
        {
            var resultado = await libroApplication.RegistroDetalleFisico(detalleLibroFisicoRespuestaDto);
            return resultado;
        }

        [HttpPut]
        [Route("editarLibro")]
        public async Task<OperationResult<string>> EditarLibro([FromBody] EditarLibroPeticionDto editarLibroPeticionDto)
        {
            var resultado = await libroApplication.EditarLibro(editarLibroPeticionDto);
            return resultado;
        }
    }
}
