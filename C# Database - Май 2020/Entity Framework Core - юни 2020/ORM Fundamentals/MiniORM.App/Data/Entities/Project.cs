namespace MiniORM.App.Data.Entities
{
    using System.Collections.Generic;

    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<EmployeesProject> EmployeeProjects { get; }
    }
}
