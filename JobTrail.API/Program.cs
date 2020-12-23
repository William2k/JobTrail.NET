using JobTrail.Core;
using JobTrail.Core.Entities;
using JobTrail.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
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
                context.Database.EnsureCreated();

                var user = new User { FirstName = "Test", LastName = "Test", Email = "Test@email.com", PhoneNumber = "01234567892" };
                var job = new Job { AssignedUser = user, Name = "TestJob", Priority = Priority.Medium };

                await context.Users.AddAsync(user);
                await context.Jobs.AddAsync(job);

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
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
