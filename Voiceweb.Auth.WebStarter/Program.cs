using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Voiceweb.Auth.WebStarter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) => {

                    var env = hostingContext.HostingEnvironment;
                    var settings = Directory.GetFiles("Settings", "*.json");
                    settings.ToList().ForEach(setting => {
                        config.AddJsonFile(setting, optional: false, reloadOnChange: true);
                    });
                })
                .UseUrls("http://0.0.0.0:127")
                .UseStartup<Startup>()
                .Build();
    }
}
