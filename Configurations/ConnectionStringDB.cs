using Microsoft.Data.SqlClient;

namespace editorial_webapi.Configurations
{
    public class ConnectionStringDB
    {
        public SqlConnectionStringBuilder ConnectionStringApi(string Database)
        {
            var host = "192.168.1.30";
            var port = "1433";
            var user = "ylazaro";
            var pass = "123456";

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
