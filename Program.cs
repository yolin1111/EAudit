using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace EAudit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            CreateHostBuilder(args).Build().Run();
        }
        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseNLog()
                .Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                // Add_Nlog
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // var _env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    // Console.WriteLine("===========目前環境===========");
                    // Console.WriteLine(_env);
                    // Console.WriteLine("===========目前環境===========");
                    // if (_env == "Development")
                    // {
                    //     webBuilder.UseStartup<Startup>();
                    // }
                    // if (_env == "Production")
                    // {
                    //     webBuilder.UseStartup<Startup>()
                    //    .UseUrls("http://172.25.144.129:8080");
                    // }

                    //正式區
                    webBuilder.UseStartup<Startup>()
                       .UseUrls("http://172.25.144.129:8080");
                    //開發區
                    // webBuilder.UseStartup<Startup>();
                });
    }
}
