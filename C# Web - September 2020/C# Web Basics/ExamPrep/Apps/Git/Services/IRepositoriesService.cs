using Git.ViewModels.InputModels;
using Git.ViewModels.Repository;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        string Create(RepositoryInputModel model, string userId);

        IEnumerable<RepositoryViewModel> GetAllPublicRepositories();

        string GetNameById(string Id);
    }
}
