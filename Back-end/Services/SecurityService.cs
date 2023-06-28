
using System.Security.Cryptography;
using System.Text;
namespace Back_end.Services;

public class SecurityService : ISecurityService
{
    public byte[] ApplyHash(string pass, string salt)
    {
        string passSalt = pass + salt;

        using var sha = SHA256.Create();
        
        var bytes = Encoding.UTF8.GetBytes(passSalt);
        var hasBytes = sha.ComputeHash(bytes);

        return hasBytes;
    }

    public string GenerateSalt()
    {
        byte[] bytes = new byte[12];
        Random.Shared.NextBytes(bytes);
        string str = Convert.ToBase64String(bytes);

        return str;
    }

    public bool Validate(byte[] password, byte[] input)
    {
        for(int i = 0; i < password.Length; i++)
        {
            if(input[i] != password[i])
                return false;
        }

        return true;
    }
}
