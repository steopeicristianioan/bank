using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace bank
{
    public class Useful
    {
        public static string getConnectionString(string connection = "Default")
        {
            string output = "";

            var builder = new ConfigurationBuilder()
                .SetBasePath(@"C:\\C#\\Desktop\\bankApp\\bank\\bank\\")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            output = config.GetConnectionString(connection);
            return output;
        }
    }
}
