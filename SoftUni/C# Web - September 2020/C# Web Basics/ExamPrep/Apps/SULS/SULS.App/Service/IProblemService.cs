using SULS.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.Service
{
    public interface IProblemService
    {
        void CreateProblem(string name, int points);

        IEnumerable<HomePageProblemViewModel> GetAllProblems();

        DetailProblemViewModel GetProblemById(string Id);

        string GetProblemName(string Id);
    }
}
