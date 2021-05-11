using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace corta_e_tchau_backend
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
                    var debug = Environment.GetEnvironmentVariable("debug");
                    if(debug.Equals("true"))
                    {
                        webBuilder.UseStartup<Startup>();
                    }
                    else
                    {
                        var port = Environment.GetEnvironmentVariable("PORT");
                        webBuilder.UseStartup<Startup>().UseUrls("http://*:" + port); ;
                    }
                });
    }
}
