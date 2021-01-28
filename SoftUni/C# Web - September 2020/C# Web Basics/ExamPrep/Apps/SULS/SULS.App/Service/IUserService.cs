using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.Service
{
    public interface IUserService
    {
        string CreateUser(string username, string email, string password);

        bool IsEmailAvailable(string email);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);
    }
}
