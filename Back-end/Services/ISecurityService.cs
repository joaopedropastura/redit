public interface ISecurityService
{
    string GenerateSalt();
    string ApplyHash(string pass, string salt);
}