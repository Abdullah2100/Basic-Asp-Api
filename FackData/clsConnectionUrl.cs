using Microsoft.Extensions.Configuration;
using System.IO;

namespace FackData
{
    public class clsConnectionUrl
    {
        public static IConfiguration connectionUrl = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json").Build();
    }
}
