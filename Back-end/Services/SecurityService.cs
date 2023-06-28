
using System.Security.Cryptography;
using System.Text;
namespace Back_end.Services;

public class SecurityService : ISecurityService
{
    public string ApplyHash(string pass, string salt)
    {
        string passSalt = pass + salt;

        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(passSalt);
        var hasBytes = sha.ComputeHash(bytes);
        var hash = Convert.ToBase64String(hasBytes);

        return hash;
    }

    public string GenerateSalt()
    {
        byte[] bytes = new byte[12];
        Random.Shared.NextBytes(bytes);
        string str = Convert.ToBase64String(bytes);

        return str;
    }
}
