using System;
using System.Globalization;

namespace Git.ViewModels.Commit
{
    public class CommitViewMolde
    {
        public string Id { get; set; }

        public string repoName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnToString => this.CreatedOn.ToString(CultureInfo.InvariantCulture);

        public string Description { get; set; }
    }
}
