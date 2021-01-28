using SULS.App.Data;
using SULS.App.Data.Models;
using System;
using System.Linq;

namespace SULS.App.Service
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ApplicationDbContext db;
        private readonly Random random;

        public SubmissionService(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }

        public void Create(string problemId, string userId, string code)
        {
            var problemMaxPoints = this.db.Problems
                .Where(x => x.Id == problemId)
                .Select(x => x.Points).FirstOrDefault();

            var entity = new Submission() 
            { 
                ProblemId = problemId,
                UserId = userId,
                Code = code,
                AchievedResult = this.random.Next(1, problemMaxPoints + 1),
                CreatedOn = DateTime.UtcNow,
            };

            this.db.Submissions.Add(entity);
            this.db.SaveChanges();
        }

        public void Delete(string Id)
        {
            var entity = this.db.Submissions.FirstOrDefault(x => x.Id == Id);

            this.db.Submissions.Remove(entity);
            this.db.SaveChanges();
        }
    }
}
