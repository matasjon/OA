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
            await AddCreatorOne();
            await AddCreatorTwo();
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
                    await _userManager.AddToRolesAsync(newAdminUser, OnActRoles.All);
                }
            }
        }

        private async Task AddCreatorOne()
        {
            var newCreatorUser = new OnActUser()
            {
                UserName = "creator1",
                Email = "ac1@ac1.com"
            };

            var existingCreatorUser = await _userManager.FindByNameAsync(newCreatorUser.UserName);

            if (existingCreatorUser == null)
            {
                var createCreatorUserResult = await _userManager.CreateAsync(newCreatorUser, "Varskietis12*");
                if (createCreatorUserResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newCreatorUser, OnActRoles.ActivityCreator);
                }
            }
        }

        private async Task AddCreatorTwo()
        {
            var newCreatorUser = new OnActUser()
            {
                UserName = "creator2",
                Email = "ac2@ac2.com"
            };

            var existingCreatorUser = await _userManager.FindByNameAsync(newCreatorUser.UserName);

            if (existingCreatorUser == null)
            {
                var createCreatorUserResult = await _userManager.CreateAsync(newCreatorUser, "Varskietis12*");
                if (createCreatorUserResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newCreatorUser, OnActRoles.ActivityCreator);
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
