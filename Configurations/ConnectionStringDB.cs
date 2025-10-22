using Microsoft.Data.SqlClient;

namespace editorial_webapi.Configurations
{
    public class ConnectionStringDB
    {
        public SqlConnectionStringBuilder ConnectionStringApi(string Database)
        {
            var host = GlobalConfiguration.Configuration["dotnet.webapi.host"];
            var port = GlobalConfiguration.Configuration["dotnet.webapi.port"];
            var user = GlobalConfiguration.Configuration["dotnet.webapi.user"];
            var pass = GlobalConfiguration.Configuration["dotnet.webapi.pass"];

            SqlConnectionStringBuilder builder = new()
            {
                DataSource = $"{host},{port}",
                InitialCatalog = Database,
                UserID = user,
                Password = pass,
            };

            builder.ApplicationName = "dispositivos.webapi";
            builder.Encrypt = false;
            builder["Trusted_Connection"] = false;

            return builder;
        }
    }
}
