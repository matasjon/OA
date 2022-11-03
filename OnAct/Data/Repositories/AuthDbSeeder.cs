using Microsoft.AspNetCore.Identity;
using OnAct.Auth.Model;

namespace OnAct.Data.Repositories
{
    public class AuthDbSeeder
    {
        private readonly UserManager<OnActUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthDbSeeder(UserManager<OnActUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await AddDefaultRoles();
            await AddAdminUser();
        }

        private async Task AddAdminUser()
        {
            var newAdminUser = new OnActUser()
            {
                UserName = "admin",
                Email = "admin@admin.com"
            };

            var existingAdminUser = await _userManager.FindByNameAsync(newAdminUser.UserName);

            if (existingAdminUser == null)
            {
                var createAdminUserResult = await _userManager.CreateAsync(newAdminUser, "Varskietis12*");
                if (createAdminUserResult.Succeeded)
                {
                    //cia klaida del all string
                    await _userManager.AddToRolesAsync(newAdminUser, OnActRoles.All);
                }
            }
        }

        private async Task AddDefaultRoles()
        {
            foreach (var role in OnActRoles.All)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);

                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }

            }
        }
    }
}
