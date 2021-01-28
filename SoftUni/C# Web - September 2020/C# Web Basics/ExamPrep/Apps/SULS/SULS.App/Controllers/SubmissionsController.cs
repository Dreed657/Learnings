using Suls.ViewModels.Submissions;
using SULS.App.Service;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemService problemsService;
        private readonly ISubmissionService submissionsService;

        public SubmissionsController(
            IProblemService problemsService,
            ISubmissionService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }

        [HttpGet]
        public HttpResponse Create(string Id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var model = new CreateViewModel() { ProblemId = Id, Name = this.problemsService.GetProblemName(Id) };
            return this.View(model);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(code) || code.Length < 30 || code.Length > 800)
            {
                return this.Error("Code should be between 30 and 800 characters.");
            }

            this.submissionsService.Create(problemId, this.GetUserId(), code);
            return this.Redirect("/");
        }

        [HttpGet]
        public HttpResponse Delete(string Id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("Users/Login");
            }

            this.submissionsService.Delete(Id);
            return this.Redirect("/");
        }
    }
}
