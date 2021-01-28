namespace ApiTest.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string userId, string userName, string secret);
    }
}
