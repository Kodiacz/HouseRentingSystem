﻿namespace HouseRentingSystem.Web.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app)
        {
            using var scopedService = app.ApplicationServices.CreateScope();

            var service = scopedService.ServiceProvider;

            var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    return;
                }

                var role = new IdentityRole { Name = AdminRoleName };

                await roleManager.CreateAsync(role);

                var admin = await userManager.FindByNameAsync(AdminEmail);
                await userManager.AddToRoleAsync(admin, role.Name);
            })
            .GetAwaiter()
            .GetResult();

            return app;
        }
    }
}
