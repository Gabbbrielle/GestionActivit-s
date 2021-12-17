using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Web;
using System.ComponentModel.DataAnnotations;
using GestionActivités.Models.Activites;

namespace GestionActivités
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
                    webBuilder.UseStartup<Startup>();
                });
    }
    
}
