using System.Data.SqlClient;

namespace CRUDCORE.Data
{
    public class Connection
    {
        private string cadenaSQL = string.Empty;

        public Connection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value ?? string.Empty;
        }

        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    }

}