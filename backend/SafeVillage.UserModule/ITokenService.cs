namespace SafeVillage.UserModule;

internal interface ITokenService
{
    string CreateToken(AppUser user);
}
