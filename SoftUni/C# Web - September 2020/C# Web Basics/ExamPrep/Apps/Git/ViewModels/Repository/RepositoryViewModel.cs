using System;
using System.Globalization;

namespace Git.ViewModels.Repository
{
    public class RepositoryViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string OwnerName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnToString => this.CreatedOn.ToString(CultureInfo.InvariantCulture);

        public int CommitsCount { get; set; }
    }
}
