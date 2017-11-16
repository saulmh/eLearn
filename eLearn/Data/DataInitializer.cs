using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        Administrator,
        Student,
        Professor,
    }

    public enum RoleEnumViewModel
    {
        [Display(Name = "Estudiante")]
        Student,
        [Display(Name = "Professor")]
        Professor,
    }
}
