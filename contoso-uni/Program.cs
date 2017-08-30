using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using ContosoUniversity.Data;


namespace ContosoUniversity
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IWebHost host = BuildWebHost(args);
            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                try
                {
                    SchoolContext context = services.GetRequiredService<SchoolContext>();
                    await DbInitializer.InitializeAsync(context);
                }
                catch (Exception exception)
                {
                    ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "An error occured while seeding the database.");
                }
            }
            await host.RunAsync();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
