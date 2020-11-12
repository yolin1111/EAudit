using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EAudit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
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
