using SharedTrip.ViewModels;

namespace SharedTrip.Services
{
    public interface IUserService
    {
        string CreateUser(string username, string email, string password);

        string GetUserId(LoginInputModel model);

        bool IsEmailAvailable(string email);

        bool IsUsernameAvailable(string username);
    }
}
