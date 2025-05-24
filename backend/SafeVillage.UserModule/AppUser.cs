using Ardalis.GuardClauses;

namespace SafeVillage.UserModule;
internal class AppUser
{
    public int Id { get; private set; }
    public string Username { get; private set; }
    public string PasswordHash { get; private set; }
    public string PasswordSalt { get; private set; }
    public List<AppRole> Roles { get; private set; } = [];

    public AppUser()
    {
        
    }

    private AppUser(AppUser user)
    {
        Id = user.Id;
        Username = user.Username;
        PasswordHash = user.PasswordHash;
        PasswordSalt = user.PasswordSalt;
        Roles = [.. user.Roles.Select(e => new AppRole(e))];
    }

    private AppUser(string username,
        string passwordHash,
        string passwordSalt,
        IReadOnlyCollection<AppRole> roles)
    {
        Username = username;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        Roles = [.. roles.Select(e => new AppRole(e))];
    }

    public static AppUser Create(string username,
        string passwordHash,
        string passwordSalt,
        IReadOnlyCollection<AppRole> roles)
    {
        username = Guard.Against.NullOrEmpty(username);
        username = username.ToUpperInvariant();
        passwordHash = Guard.Against.NullOrEmpty(passwordHash);
        passwordSalt = Guard.Against.NullOrEmpty(passwordSalt);
        roles = Guard.Against.Null(roles);

        roles = [.. roles.Select(e => new AppRole(e))];

        return new(username, passwordHash, passwordSalt, roles);
    }
}
