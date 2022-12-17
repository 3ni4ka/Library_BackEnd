using Library;
using Microsoft.Extensions.FileProviders;
using NLog.Extensions.Logging;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.WebHost.UseUrls();

        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureAppConfiguration(configBuilder =>
                {
                     var appPath = AppDomain.CurrentDomain.BaseDirectory;
                     var configPath = Path.Combine(appPath, @"Configs");
                    if (Directory.Exists(configPath))
                        configBuilder.AddJsonFile(new PhysicalFileProvider(configPath), @"config.json", false, false);
                    else
                        configBuilder.AddJsonFile("config.json");
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                     webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(configLogging =>
                {
                    configLogging.AddConsole();
                    configLogging.AddDebug();
                    configLogging.AddNLog("Nlog.config");
                });
    
}