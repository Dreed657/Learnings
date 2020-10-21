using SharedTrip.Services;
using SharedTrip.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel model)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Trips/All");
            }

            var userId = this.userService.GetUserId(model);

            if (userId == null)
            {
                return this.Error("Invalid login credentials.");
            }

            this.SignIn(userId);
            return this.Redirect("/Trips/All");
        }

        [HttpGet]
        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel model)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Trips/All");
            }

            if (string.IsNullOrEmpty(model.username) || model.username.Length < 5 || model.username.Length > 20)
            {
                return this.Error("Username must be between 5 and 20 characters long.");
            }

            if (string.IsNullOrEmpty(model.password) || model.password.Length < 6 || model.password.Length > 20)
            {
                return this.Error("Password must be between 6 and 20 characters long.");
            }

            if (string.IsNullOrEmpty(model.email))
            {
                return this.Error("Email is required for registration.");
            }

            if (!this.userService.IsEmailAvailable(model.email))
            {
                return this.Error("Email is already taken.");
            }

            if (!this.userService.IsUsernameAvailable(model.username))
            {
                return this.Error("Username is already taken.");
            }

            if (model.password != model.confirmPassword)
            {
                return this.Error("Both passwords should be identical.");
            }

            this.userService.CreateUser(model.username, model.email, model.password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
