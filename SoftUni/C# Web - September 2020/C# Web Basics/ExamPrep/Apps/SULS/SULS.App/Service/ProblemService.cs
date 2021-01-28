using SULS.App.Data;
using SULS.App.Data.Models;
using SULS.App.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SULS.App.Service
{
    public class ProblemService : IProblemService
    {
        private readonly ApplicationDbContext db;

        public ProblemService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateProblem(string name, int points)
        {
            var entity = new Problem()
            {
                Name = name,
                Points = points,
            };

            this.db.Problems.Add(entity);
            this.db.SaveChanges();
        }

        public IEnumerable<HomePageProblemViewModel> GetAllProblems()
        {
            return this.db.Problems
                .Select(x => new HomePageProblemViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Count = x.Submissions.Count(),
                }).ToList();
        }

        public DetailProblemViewModel GetProblemById(string Id)
        {
            return this.db.Problems
                .Where(x => x.Id == Id)
                .Select(x => new DetailProblemViewModel() 
                { 
                    Id = x.Id,
                    Name = x.Name,
                    Points = x.Points,
                    Submissions = x.Submissions.Select(y => new SubmissionViewModel()
                    {
                        SubmissionId = y.Id,
                        Username = y.User.Username,
                        AchievedResult = y.AchievedResult,
                        CreatedOn = y.CreatedOn,
                    }).ToList(),
                })
                .FirstOrDefault();
        }

        public string GetProblemName(string Id)
        {
            return this.db.Problems.FirstOrDefault(x => x.Id == Id)?.Name;
        }
    }
}
