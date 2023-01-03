using Microsoft.AspNetCore.Identity;

namespace DrPet.Data.SeedData
{
    public class RoleSeedService : IRoleSeedService
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public RoleSeedService(RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedRoleAsync()
        {
            if (!await _roleManager.RoleExistsAsync(RoleHelper.Administrators))
            {
                await _roleManager.CreateAsync(new IdentityRole<int> { Name = RoleHelper.Administrators });
            }

            if (!await _roleManager.RoleExistsAsync(RoleHelper.Doctors))
            {
                await _roleManager.CreateAsync(new IdentityRole<int> { Name = RoleHelper.Doctors });
            }

            if (!await _roleManager.RoleExistsAsync(RoleHelper.Assistants))
            {
                await _roleManager.CreateAsync(new IdentityRole<int> { Name = RoleHelper.Assistants });
            }
        }
    }
}
