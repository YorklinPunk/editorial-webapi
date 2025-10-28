using editorial_webapi.Areas.Interface;
using editorial_webapi.Configurations;
using editorial_webapi.Dto.Libro;
using System.Data;

namespace editorial_webapi.Areas.Implementation
{
    public class LibroApplication : ILibroApplication
    {
        public async Task<OperationResult<List<ListaLibroRespuestaDto>>> ListaLibros()
        {
            var resultado = new OperationResult<List<ListaLibroRespuestaDto>> { isValid = false, exceptions = new List<OperationException>() };
            try
            {
                var ds = await new ProcedureGeneral().Procedure(new ProcedureRequestDto
                {
                    Procedimiento = "dbo.ProcLibreria",
                    Parametro = "",
                    Indice = 10
                });


                resultado.isValid = true;
                resultado.content = [];

                foreach (var libro in (from x in ds.Tables[0].AsEnumerable() select x))
                {
                    resultado.content.Add(new ListaLibroRespuestaDto()
                    {
                        IdLibro = libro.Field<int>("IdLibro"),
                        Autor = libro.Field<string>("Autor") ?? "",
                        Titulo = libro.Field<string>("Titulo") ?? "",
                        Genero = libro.Field<string>("Genero") ?? "",
                        Precio = libro.Field<decimal>("Precio"),
                        Editorial = libro.Field<string>("Editorial") ?? "",
                        Categoria = libro.Field<string>("Categoria") ?? "",
                        TipoLibro = libro.Field<string>("TipoLibro") ?? ""
                    });
                }

                var response = ds.Tables[0].AsEnumerable();
                return resultado;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }

        public async Task<OperationResult<DetalleLibroDigitalRespuestaDto>> ListaDetalleDigital(int IdLibro)
        {
            var resultado = new OperationResult<DetalleLibroDigitalRespuestaDto> { isValid = false, exceptions = new List<OperationException>() };
            try
            {
                var ds = await new ProcedureGeneral().Procedure(new ProcedureRequestDto
                {
                    Procedimiento = "dbo.ProcLibreria",
                    Parametro = $"{IdLibro}",
                    Indice = 14
                });


                resultado.isValid = true;

                var respBd = (from x in ds.Tables[0].AsEnumerable() select x).FirstOrDefault();
                resultado.content = new DetalleLibroDigitalRespuestaDto()
                {
                    IdLibro = respBd.Field<int>("IdLibro"),
                    FormatoArchivo = respBd.Field<string>("FormatoArchivo") ?? "",
                    TamanoMB = respBd.Field<double>("TamanoMB"),
                    UrlDescarga = respBd.Field<string>("UrlDescarga") ?? ""
                };

                return resultado;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }

        public async Task<OperationResult<DetalleLibroFisicoRespuestaDto>> ListaDetalleFisico(int IdLibro)
        {
            var resultado = new OperationResult<DetalleLibroFisicoRespuestaDto> { isValid = false, exceptions = new List<OperationException>() };
            try
            {
                var ds = await new ProcedureGeneral().Procedure(new ProcedureRequestDto
                {
                    Procedimiento = "dbo.ProcLibreria",
                    Parametro = $"{IdLibro}",
                    Indice = 13
                });


                resultado.isValid = true;

                var respBd = (from x in ds.Tables[0].AsEnumerable() select x).FirstOrDefault();
                resultado.content = new DetalleLibroFisicoRespuestaDto()
                {
                    IdLibro = respBd.Field<int>("IdLibro"),
                    Stock = respBd.Field<int>("Stock"),
                    TipoTapa = respBd.Field<string>("TipoTapa") ?? "",
                    PesoGramos = respBd.Field<decimal>("PesoGramos")
                };

                return resultado;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }

        public async Task<OperationResult<string>> RegistroLibro(RegistroLibroPeticionDto registroLibroPeticionDto)
        {
            var resultado = new OperationResult<string> { isValid = false, exceptions = new List<OperationException>() };
            try
            {
                var rpp = registroLibroPeticionDto;
                var parametros = $"{rpp.Titulo}|{rpp.Autor}|{rpp.Genero}|{rpp.Precio}|{rpp.Editorial}|{rpp.IdCategoria}|{rpp.TipoLibro}|{rpp.Stock}|{rpp.TipoTapa}|{rpp.PesoGramos}|{rpp.FormatoArchivo}|{rpp.TamanoMB}|{rpp.UrlDescarga}";

                var ds = await new ProcedureGeneral().Procedure(new ProcedureRequestDto()
                {
                    Procedimiento = "dbo.ProcLibreria",
                    Parametro = parametros,
                    Indice = 20
                });

                var respBd = (from x in ds.Tables[0].AsEnumerable() select x).FirstOrDefault();

                resultado.isValid = respBd?.Field<int>("CodResultado") == 1;
                resultado.content = respBd?.Field<string>("DesResultado") ?? "";

                return resultado;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }

        public async Task<OperationResult<string>> RegistroDetalleDigital(DetalleLibroDigitalRespuestaDto detalleLibroDigitalRespuestaDto)
        {
            var resultado = new OperationResult<string> { isValid = false, exceptions = new List<OperationException>() };
            try
            {
                var rpp = detalleLibroDigitalRespuestaDto;
                var parametros = $"{rpp.IdLibro}|{rpp.FormatoArchivo}|{rpp.TamanoMB}|{rpp.UrlDescarga}";

                var ds = await new ProcedureGeneral().Procedure(new ProcedureRequestDto()
                {
                    Procedimiento = "dbo.ProcLibreria",
                    Parametro = parametros,
                    Indice = 32
                });

                var respBd = (from x in ds.Tables[0].AsEnumerable() select x).FirstOrDefault();

                resultado.isValid = respBd?.Field<int>("CodResultado") == 1;
                resultado.content = respBd?.Field<string>("DesResultado") ?? "";

                return resultado;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }

        public async Task<OperationResult<string>> RegistroDetalleFisico(DetalleLibroFisicoRespuestaDto detalleLibroFisicoRespuestaDto)
        {
            var resultado = new OperationResult<string> { isValid = false, exceptions = new List<OperationException>() };
            try
            {
                var rpp = detalleLibroFisicoRespuestaDto;
                var parametros = $"{rpp.IdLibro}|{rpp.Stock}|{rpp.TipoTapa}|{rpp.PesoGramos}";

                var ds = await new ProcedureGeneral().Procedure(new ProcedureRequestDto()
                {
                    Procedimiento = "dbo.ProcLibreria",
                    Parametro = parametros,
                    Indice = 31
                });

                var respBd = (from x in ds.Tables[0].AsEnumerable() select x).FirstOrDefault();

                resultado.isValid = respBd?.Field<int>("CodResultado") == 1;
                resultado.content = respBd?.Field<string>("DesResultado") ?? "";

                return resultado;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }

        public async Task<OperationResult<string>> EditarLibro(EditarLibroPeticionDto editarLibroPeticionDto)
        {
            var resultado = new OperationResult<string> { isValid = false, exceptions = [] };
            try
            {
                var rpp = editarLibroPeticionDto;
                var parametros = $"{rpp.IdLibro}|{rpp.Titulo}|{rpp.Autor}|{rpp.Genero}|{rpp.Precio}|{rpp.Editorial}|{rpp.IdCategoria}|{rpp.TipoLibro}|{rpp.Stock}|{rpp.TipoTapa}|{rpp.PesoGramos}|{rpp.FormatoArchivo}|{rpp.TamanoMB}|{rpp.UrlDescarga}";

                var ds = await new ProcedureGeneral().Procedure(new ProcedureRequestDto()
                {
                    Procedimiento = "dbo.ProcLibreria",
                    Parametro = parametros,
                    Indice = 30
                });

                var respBd = (from x in ds.Tables[0].AsEnumerable() select x).FirstOrDefault();

                resultado.isValid = respBd?.Field<int>("CodResultado") == 1;
                resultado.content = respBd?.Field<string>("DesResultado") ?? "";

                return resultado;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
