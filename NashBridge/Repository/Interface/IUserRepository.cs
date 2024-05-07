using Microsoft.AspNetCore.Identity;

namespace NashBridge.Repository.Interface
{
    public interface IUserRepository
    {
      

        Task<IEnumerable<IdentityUser>> GetAllAsync();

        Task<IdentityUser?> GetByIdAsync(string id);
        Task <IList<string>> GetRolesAsync(IdentityUser user);

        Task<IdentityUser?> UpdateAsync(IdentityUser user);

        Task<IdentityUser?> DeleteAsync(Guid id);

        Task<bool> isAdminUser(IdentityUser user);

        Task<int> GetCount();

    }
}
