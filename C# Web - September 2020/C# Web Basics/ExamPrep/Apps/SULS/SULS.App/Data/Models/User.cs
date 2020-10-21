using SUS.MvcFramework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SULS.App.Data.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submission>();
        }

        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
