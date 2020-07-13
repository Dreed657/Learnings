namespace MiniORM.App
{
    using System.Linq;
    using Data;
    using Data.Entities;

    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Server=.;Database=MiniORM;Integrated Security=True";

            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "John",
                MiddleName = "Random5",
                LastName = "Doe",
                DepartmentId = context.Departments.Last().Id,
                IsEmployed = true
            });

            context.SaveChanges();
        }
    }
}
