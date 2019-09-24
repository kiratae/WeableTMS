using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Weable.TMS.Infrastructure.Extension;
using Weable.TMS.Model.Data;
using Weable.TMS.Model.Enumeration;

namespace Weable.TMS.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Build the application host
            var host = CreateWebHostBuilder(args).Build();

            try
            {
                // Seed the database
                // TODO: Refactor this
                using (var scope = host.Services.CreateScope())
                {
                    var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                    var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                    // Get the list of the roles in the enum
                    Role[] roles = (Role[])Enum.GetValues(typeof(Role));
                    foreach (var r in roles)
                    {
                        // Create an identity role object out of the enum value
                        var identityRole = new IdentityRole
                        {
                            Id = r.GetRoleName(),
                            Name = r.GetRoleName()
                        };

                        // Create the role if it doesn't already exist
                        if (!await roleManager.RoleExistsAsync(roleName: identityRole.Name))
                        {
                            var result = await roleManager.CreateAsync(identityRole);
                            if (!result.Succeeded)
                            {
                                // FIXME: Do not throw an Exception object
                                throw new Exception("Creating role failed");
                            }
                        }
                    }

                    Role adminRole = (Role)Enum.Parse(typeof(Role), "Admin");

                    // Our default user
                    var user = new ApplicationUser
                    {
                        FullName = "Tanaphon Kleaklom",
                        Email = "kirataetwo@gmail.com",
                        UserName = "admin",
                        LockoutEnabled = false
                    };

                    // Add the user to the database if it doesn't already exist
                    if (await userManager.FindByNameAsync(user.UserName) == null)
                    {
                        // WARNING: Do NOT check in credentials of any kind into source control


                        var result = await userManager.CreateAsync(user, password: "password");

                        if (!result.Succeeded)
                        {
                            // FIXME: Do not throw an Exception object
                            throw new Exception("Creating user failed");
                        }

                        // Assign all roles to the default user
                        result = await userManager.AddToRoleAsync(user, adminRole.GetRoleName());
                        // If you add a role to the enumafter the user is created,
                        // the role will not be assigned to the user as of now

                        if (!result.Succeeded)
                        {
                            // FIXME: Do not throw an Exception object
                            throw new Exception("Adding user to role failed");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in main program. ", ex);
                return;
            }

            host.Run();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddEventSourceLogger();
                })
                .UseStartup<Startup>();
    }
}
