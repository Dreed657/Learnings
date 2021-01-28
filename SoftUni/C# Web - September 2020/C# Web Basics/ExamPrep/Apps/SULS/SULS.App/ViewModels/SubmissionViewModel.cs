using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels
{
    public class SubmissionViewModel
    {
        public string SubmissionId { get; set; }

        public string Username { get; set; }

        public int AchievedResult { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
