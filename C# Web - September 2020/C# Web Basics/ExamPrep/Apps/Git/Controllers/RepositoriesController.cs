using Git.Services;
using Git.ViewModels.InputModels;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repoService;

        public RepositoriesController(IRepositoriesService repoService)
        {
            this.repoService = repoService;
        }

        [HttpGet]
        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var model = this.repoService.GetAllPublicRepositories();
            return this.View(model);
        }

        [HttpGet]
        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(RepositoryInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(model.Name) || model.Name.Length < 3 || model.Name.Length > 10)
            {
                return this.Error("Repository name should be between 3 and 10 characters.");
            }

            if (string.IsNullOrEmpty(model.repositoryType))
            {
                return this.Error("Privacy setting is required.");
            }

            this.repoService.Create(model, this.GetUserId());
            return this.Redirect("/Repositories/All");
        }
    }
}
