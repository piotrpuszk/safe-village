namespace SafeVillage.UserModule;

internal class AppRole
{
    public AppRoleName Name { get; private set; }

    public AppRole()
    {
        
    }

    public AppRole(AppRole role)
    {
        Name = role.Name;
    }

    private AppRole(AppRoleName name)
    {
        Name = name;
    }

    public static AppRole Create(AppRoleName roleName)
    {
        return new AppRole(roleName);
    }

}