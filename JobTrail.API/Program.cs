using JobTrail.Data;
using JobTrail.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobTrail.API
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            await CreateDbIfNotExists(host);

            host.Run();
        }

        private async static Task CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<JTContext>();
                

                var dbExisted = !context.Database.EnsureCreated();

                if (!dbExisted)
                {
                    await DbInitialiser(services);
                }
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }

        private async static Task DbInitialiser(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<Role>>();

            var roles = new string[] { "Administrator", "Manager", "User" };

            foreach (var item in roles)
            {
                var role = new Role(item);
                await roleManager.CreateAsync(role);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
