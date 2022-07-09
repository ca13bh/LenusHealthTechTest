namespace LenusHealthTechTest
{
    using LenusHealthTechTest.Interfaces.Core;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var scope = host.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<BookStoreContext>();

            // Get all startup tasks
            var startupTasks = host.Services.GetServices<IStartUpTask>();
            var logger = host.Services.GetServices<ILogger>().FirstOrDefault();

            // Run each startup Tasks
            foreach (var startupTask in startupTasks)
            {
                logger.LogInformation($"Executing start up task {startupTask.GetType().Name}");
                await startupTask.Execute(context);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
