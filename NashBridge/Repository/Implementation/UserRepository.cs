using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NashBridge.Data;
using NashBridge.Repository.Interface;

namespace NashBridge.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly AuthDbContext authDb;

        public UserRepository(UserManager<IdentityUser> userManager, AuthDbContext authDb)
        {
            this.userManager = userManager;
            this.authDb = authDb;
        }
       
        public Task<IdentityUser?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IdentityUser>> GetAllAsync()
        {
            var users = await userManager.Users.ToListAsync();
            return users;
        }

        public async Task<IdentityUser?> GetByIdAsync(string id)
        {
            return await userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<int> GetCount()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<string>> GetRolesAsync(IdentityUser user)
        {
            return await userManager.GetRolesAsync(user);
        }

        public async Task<bool> isAdminUser(IdentityUser user)
        {
            if(user == null) return false;

            var userRoles = await GetRolesAsync(user);
            return userRoles.Any(x => x.ToString().ToLower() == "writer");
        }

        public Task<IdentityUser?> UpdateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }
    }
}
