using AuthrizationMicroservice.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthrizationMicroservice.Data
{
    public class IdentityDbInit
    {
        //This example just creates an Administrator role and one Admin users
        public static async Task Initialize(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            //create database schema if none exists
            // _context.Database.EnsureCreated();
            context.Database.Migrate();
            //If there is already an Administrator role, abort
            if (context.Roles.Any(r => r.Name == "Administrator"))
            {
                return;
            }
            else
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }
            if (context.Roles.Any(x => x.Name == "Employee"))
            {
                return;
            }
            else
            {
                await roleManager.CreateAsync(new IdentityRole("Employee"));
            }

            if (context.Roles.Any(y => y.Name == "Hr"))
            {
                return;
            }
            else
            {
                await roleManager.CreateAsync(new IdentityRole("Hr"));
            }


            if (context.Users.Any(z => z.UserName == "Vishnu")) return;
            //Create the default Admin account and apply the Administrator role
            string user = "Vishnu";
            string email = "admin@swiftsenseitsolutions.com";
            string password = "Admin@123";
            await userManager.CreateAsync(new ApplicationUser { UserName = user, Email = email, EmailConfirmed = true }, password);
            await userManager.AddToRoleAsync(await userManager.FindByNameAsync(user), "Administrator");
        }
    }
}
