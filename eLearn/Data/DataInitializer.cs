using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearn.Data
{
    public static class DataInitializer
    {
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (var role in Enum.GetNames(typeof(Roles)))
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }

    public enum Roles
    {
        Sudo,
        Student,
        Administrator,
        Professor,
    }

    public enum RoleEnumViewModel
    {
        Student,
        Administrator,
        Author,
    }
}
