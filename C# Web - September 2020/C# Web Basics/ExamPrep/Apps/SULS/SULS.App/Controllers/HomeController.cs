using SULS.App.Service;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemService problemService;

        public HomeController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                var problems = this.problemService.GetAllProblems();
                return this.View(problems, "IndexLoggedIn");
            }
            else
            {
                return this.View();
            }
        }
    }
}