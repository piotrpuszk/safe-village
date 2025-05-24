namespace SafeVillage.UserModule;

internal interface IUserRepository
{
    Task AddAsync(AppUser user);
    Task<AppUser?> GetByUsernameAsync(string username);
    Task<AppUser?> GetByUsernameNoTrackingAsync(string username);
    Task<int> SaveChangesAsync();
}
