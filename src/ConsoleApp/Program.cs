using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Services;
using Microsoft.EntityFrameworkCore;
using Orm.DataBase;

namespace baseConsole_net5
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = AppStartUp();
            var main = ActivatorUtilities.CreateInstance<MainService>(host.Services);
            main.Run();
        }

        static void ConfigSetup(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
        }

        static IHost AppStartUp()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            ConfigSetup(builder);

            IConfiguration configuration = builder.Build();

            

            // definig Serilog Configs
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Information("Create and config Host.");
            Log.Information(Directory.GetCurrentDirectory().ToString());
            // DI Container
            var host = Host.CreateDefaultBuilder()
                        .ConfigureServices((ContextBoundObject, services) =>
                        {
                            services.AddDbContext<ApplicationDBContext>(options => options.UseMySql(configuration.GetConnectionString("DefaultConnection"), MySqlServerVersion.LatestSupportedServerVersion));

                            services.AddTransient<MainService>();
                        })
                        .UseSerilog()
                        .Build();
            return host;
        }
    }


}
