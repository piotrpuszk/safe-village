using Microsoft.EntityFrameworkCore;

namespace SafeVillage.UserModule;

internal class UserRepository(UserContext context) : IUserRepository
{
    public async Task AddAsync(AppUser user)
    {
        await context.AddAsync(user);
    }

    public async Task<AppUser?> GetByUsernameAsync(string username)
    {
        return await context.Users.FirstOrDefaultAsync(e => e.Username == username.ToUpperInvariant());
    }

    public async Task<AppUser?> GetByUsernameNoTrackingAsync(string username)
    {
        return await context.Users.AsNoTracking().FirstOrDefaultAsync(e => e.Username == username.ToUpperInvariant());
    }

    public Task<int> SaveChangesAsync()
    {
        return context.SaveChangesAsync();
    }
}
