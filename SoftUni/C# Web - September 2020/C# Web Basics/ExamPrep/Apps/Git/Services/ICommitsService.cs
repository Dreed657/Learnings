using Git.ViewModels.Commit;
using System.Collections.Generic;

namespace Git.Services
{
    public interface ICommitsService
    {
        string Create(string description, string userId, string repoId);

        IEnumerable<CommitViewMolde> GetAll(string userId);

        bool IsUserACreator(string userId, string commitId);

        bool Delete(string Id);
    }
}
