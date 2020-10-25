using Git.Services;
using Git.ViewModels.Commit;
using Microsoft.Extensions.Options;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(ICommitsService commitsService, IRepositoriesService repositoriesService)
        {
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }

        [HttpGet]
        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var models = this.commitsService.GetAll(this.GetUserId());
            return this.View(models);
        }

        [HttpGet]
        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var repoName = this.repositoriesService.GetNameById(id);
            var model = new CreateCommitViewModel() { Id = id, Name = repoName };
            return this.View(model);
        }

        [HttpPost] 
        public HttpResponse Create(string description, string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(description) || description.Length < 3)
            {
                return this.Error("Description should be more then 3 characters");
            }

            this.commitsService.Create(description, this.GetUserId(), id);
            return this.Redirect("/Repositories/All");
        }

        [HttpGet]
        public HttpResponse Delete(string Id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.commitsService.IsUserACreator(this.GetUserId(), Id))
            {
                return this.Error("You must be owner of the commit to delete it.");
            }

            this.commitsService.Delete(Id);
            return this.Redirect("/Commits/All");
        }
    }
}
