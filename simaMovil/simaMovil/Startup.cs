using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Xamarin.Essentials;
using simaMovil.Services;

namespace simaMovil
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static void Init()
        {
            //var a = Assembly.GetExecutingAssembly();
            //var stream = a.GetManifestResourceStream("simaMovil.appsettings.json");

            var host = new HostBuilder()
                        .ConfigureHostConfiguration(c =>
                        {                
                            c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
                        //    c.AddJsonStream(stream);
                        })
                        .ConfigureServices((c, x) =>
                        {                
                            ConfigureServices(c, x);
                        })                        
                        .Build();
                        
            ServiceProvider = host.Services;
        }

        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            services.AddSingleton<IRestService, RestService>();
        }

    }
}
