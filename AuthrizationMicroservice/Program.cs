using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AuthrizationMicroservice.Data;
using AuthrizationMicroservice.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AuthrizationMicroservice
{
    public class Program
    {
        public static  void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var host = BuildWebHost(args);
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    try
                    {

                        var context = services.GetRequiredService<ApplicationDbContext>();

                        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                      await  IdentityDbInit.Initialize(context, userManager, roleManager);
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred while seeding the AuthorizationServer database.");
                    }
                }
                host.Run();
                // Do any async anything you need here without worry
            }).GetAwaiter().GetResult();
           
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
