using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Constants
    {
        IConfiguration configuration;

        public Constants()
        {
            configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();
        }

        public string GetApiUrl()
        {
            return configuration.GetSection("MySettings").GetSection("WeatherApi").Value;
        }
    }
}
