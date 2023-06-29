public interface ISecurityService
{
    string GenerateSalt();
    byte[] ApplyHash(string pass, string salt);

    bool Validate(byte[] password, byte[] input);
    
}