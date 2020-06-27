namespace MiniORM.App
{
    using System.Linq;
    using Data;
    using Data.Entities;

    class Program
    {
        static void Main(string[] args)
        {
            var conStr = @"Server=.;Database=MiniORM;Integrated Security=True;";

            var db = new SoftUniDbContextClass(conStr);

            db.Employees.Add(new Employee
            {
                FirstName = "John",
                LastName = "Doe",
                DepartmentId = db.Departments.First().Id,
                IsEmployed = true,
            });

            var employee = db.Employees.Last();
            employee.FirstName = "Modified";

            db.SaveChanges();
        }
    }
}
