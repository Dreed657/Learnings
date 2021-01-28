using System.Collections.Generic;

namespace SULS.App.ViewModels
{
    public class DetailProblemViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Points { get; set; }

        public ICollection<SubmissionViewModel> Submissions { get; set; }
    }
}
