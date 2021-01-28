using Git.Services;
using Git.ViewModels.InputModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }

            return this.View();   
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel model)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }

            if (string.IsNullOrEmpty(model.username) || model.username.Length < 5 || model.username.Length > 20)
            {
                return this.Error("Username must be between 5 and 20 characters.");
            }

            if (string.IsNullOrEmpty(model.password) || model.password.Length < 6 || model.password.Length > 20)
            {
                return this.Error("Password must be between 6 and 20 characters.");
            }

            var userId = this.usersService.GetUserId(model.username, model.password);

            if (userId == null)
            {
                return this.Error("Invalid login credentials.");
            }

            this.SignIn(userId);
            return this.Redirect("/Repositories/All");
        }

        [HttpGet]
        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel model)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }

            if (model.username == null || model.username.Length < 5 || model.username.Length > 20)
            {
                return this.Error("Invalid username. The username should be between 5 and 20 characters.");
            }

            if (!Regex.IsMatch(model.username, @"^[a-zA-Z0-9\.]+$"))
            {
                return this.Error("Invalid username. Only alphanumeric characters are allowed.");
            }

            if (string.IsNullOrWhiteSpace(model.email) || !new EmailAddressAttribute().IsValid(model.email))
            {
                return this.Error("Invalid email.");
            }

            if (model.password == null || model.password.Length < 6 || model.password.Length > 20)
            {
                return this.Error("Invalid password. The password should be between 6 and 20 characters.");
            }

            if (model.password != model.confirmPassword)
            {
                return this.Error("Passwords should be the same.");
            }

            if (!this.usersService.IsUsernameAvailable(model.username))
            {
                return this.Error("Username already taken.");
            }

            if (!this.usersService.IsEmailAvailable(model.email))
            {
                return this.Error("Email already taken.");
            }

            this.usersService.CreateUser(model.username, model.email, model.password);
            return this.Redirect("/Users/Login");
        }

        [HttpGet]
        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/Repositories/All");
        }
    }
}
