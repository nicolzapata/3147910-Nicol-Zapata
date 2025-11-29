using gestion_tienda.Areas.Identity.Data;
using gestion_tienda.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<gestion_tiendaUser>>();

        // Roles a crear
        string[] roles = { "Admin", "Cliente" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                var roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                if (roleResult.Succeeded)
                    Console.WriteLine($"Rol '{role}' creado correctamente.");
                else
                    foreach (var error in roleResult.Errors)
                        Console.WriteLine($"Error creando rol '{role}': {error.Description}");
            }
        }

        // Crear usuario Admin
        var adminEmail = "zapatanicol094@gmail.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new gestion_tiendaUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true,
                NombreCompleto = "Administrador"
            };

            var result = await userManager.CreateAsync(adminUser, "Admin123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
                Console.WriteLine("Admin creado correctamente.");
            }
            else
            {
                foreach (var error in result.Errors)
                    Console.WriteLine($"Error creando Admin: {error.Description}");
            }
        }

        // Crear usuario Cliente
        var clienteEmail = "cliente@example.com";
        var clienteUser = await userManager.FindByEmailAsync(clienteEmail);
        if (clienteUser == null)
        {
            clienteUser = new gestion_tiendaUser
            {
                UserName = clienteEmail,
                Email = clienteEmail,
                EmailConfirmed = true,
                NombreCompleto = "Cliente Ejemplo"
            };

            var result = await userManager.CreateAsync(clienteUser, "Cliente123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(clienteUser, "Cliente");
                Console.WriteLine("Cliente creado correctamente.");
            }
            else
            {
                foreach (var error in result.Errors)
                    Console.WriteLine($"Error creando Cliente: {error.Description}");
            }
        }
    }
}
