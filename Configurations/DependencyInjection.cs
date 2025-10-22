using editorial_webapi.Areas.Implementation;
using editorial_webapi.Areas.Interface;

namespace editorial_webapi.Configurations
{
    public class DependencyInjection
    {
        public static void Config(IServiceCollection services)
        {
            services.AddTransient<ILibroApplication, LibroApplication>();
        }
    }
}
