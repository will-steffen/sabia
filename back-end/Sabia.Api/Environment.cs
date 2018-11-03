using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sabia.Api
{
    public class Environment
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static IConfigurationRoot GetConfiguration()
        {
            if (Configuration != null) return Configuration;

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json", optional: true);
            Configuration = builder.Build();

            return Configuration;
        }
    }
}
