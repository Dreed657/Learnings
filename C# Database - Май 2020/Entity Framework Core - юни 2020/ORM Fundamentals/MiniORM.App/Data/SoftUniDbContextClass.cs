namespace MiniORM.App.Data
{
    using Entities;

    public class SoftUniDbContextClass : DbContext
    {
        public SoftUniDbContextClass(string conStr)
            : base(conStr)
        {
        }

        public DbSet<Employee> Employees { get; }

        public DbSet<Department> Departments { get; }

        public DbSet<Project> Projects { get; }

        public DbSet<EmployeesProject> EmployeesProjects { get; }
    }
}
