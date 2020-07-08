using System;
using System.Globalization;
using System.Linq;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            var result = GetEmployeesByFirstNameStartingWithSa(db);
            
            Console.WriteLine(result);
        }

        public static string RemoveTown(SoftUniContext db)
        {
            var townToDelete = db.Towns.Where(x => x.Name == "Seattle").First();

            var addressesToDelete = db.Addresses.Where(x => x.TownId == townToDelete.TownId);

            int addresesCount = addressesToDelete.Count();

            var empDeletedAddreses = db
                .Employees
                .Where(x => addressesToDelete.Any(a => a.AddressId == x.AddressId));

            foreach (var emp in empDeletedAddreses)
            {
                emp.AddressId = null;
            }

            db.Towns.Remove(townToDelete);

            db.Addresses.RemoveRange(addressesToDelete);

            db.SaveChanges();

            return $"{addresesCount} addresses in Seattle were deleted";
        }

        public static string DeleteProjectById(SoftUniContext db)
        {
            var sb = new StringBuilder();

            int projectId = 2;

            var projectToDelete = db.Projects.First(x => x.ProjectId == projectId);

            var empProjects = db.EmployeesProjects.Where(x => x.ProjectId == projectId);

            db.EmployeesProjects.RemoveRange(empProjects);

            db.Projects.Remove(projectToDelete);

            db.SaveChanges();

            var projects = db.Projects
                .Take(10)
                .ToList();

            foreach (var p in projects)
            {
                sb.AppendLine($"{p.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext db)
        {
            var sb = new StringBuilder();

            IQueryable<Employee> employeesToIncrease = db.Employees
                .Where(x => x.Department.Name == "Engineering" ||
                                x.Department.Name == "Tool Design" ||
                                x.Department.Name == "Marketing" ||
                                x.Department.Name == "Information Services");

            foreach (var employee in employeesToIncrease)
            {
                employee.Salary += employee.Salary * 0.12m;
            }

            db.SaveChanges();

            var AllEmployees = employeesToIncrease
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var e in AllEmployees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext db)
        {
            var sb = new StringBuilder();

            var Projects = db.Projects
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderBy(x => x.Name)
                .ThenByDescending(x => x.StartDate)
                .ToList();

            foreach (var p in Projects)
            {
                sb.AppendLine($"{p.Name}");
                sb.AppendLine($"{p.Description}");
                sb.AppendLine($"{p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext db)
        {
            var sb = new StringBuilder();

            var Departments = db
                .Departments
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(x => x.Employees.Count())
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirst = d.Manager.FirstName,
                    MenagerLast = d.Manager.LastName,
                    DepEmployees = d.Employees
                        .Take(5)
                        .Select(e => new
                        {
                            EmployeeFirst = e.FirstName,
                            EmployeeLast = e.LastName,
                            e.JobTitle,
                        })
                        .OrderBy(e => e.EmployeeFirst)
                        .ThenBy(e => e.EmployeeLast)
                        .ToList()
                })
                .ToList();

            foreach (var d in Departments)
            {
                sb.AppendLine($"{d.Name} - {d.ManagerFirst} {d.MenagerLast}");

                foreach (var x in d.DepEmployees)
                {
                    sb.AppendLine($"{x.EmployeeFirst} {x.EmployeeLast} - {x.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext db)
        {
            var sb = new StringBuilder();

            var Employee = db.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Project = e.EmployeesProjects
                        .Select(ep => ep.Project.Name)
                        .OrderBy(x => x)
                        .ToList()
                })
                .ToList();

            foreach (var e in Employee)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                
                e.Project.ForEach(x => sb.AppendLine($"{x}"));
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesInPeriod(SoftUniContext db)
        {
            var sb = new StringBuilder();

            var employees = db
                .Employees
                .Where(e => e.EmployeesProjects
                    .Any(ep => ep.Project.StartDate.Year >= 2001 &&
                               ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Project = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project
                                .StartDate
                                .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            EndDate = ep.Project.EndDate.HasValue ?
                                ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                        }).ToList()
                }).ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerFirstName}");

                foreach (var p in e.Project)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return sb.ToString().Trim();
        }
        
        public static string GetAddressesByTown(SoftUniContext db)
        {
            //TODO: NOT DONE

            var sb = new StringBuilder();

            var Addresses = db.Addresses
                .Select(a => new 
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    Count = a.Employees.Count
                })
                .OrderByDescending(a => a.Count)
                .ThenBy(x => x.TownName)
                .ThenBy(x => x.AddressText)
                .ToList();

            foreach (var a in Addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.Count} employees");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesFullInformation(SoftUniContext db)
        {
            var sb = new StringBuilder();
            var employees = db.Employees.ToList();

            foreach (var e in employees.OrderBy(x => x.EmployeeId))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext db)
        {
            var employees = db.Employees
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext db)
        {
            var sb = new StringBuilder();
            var employees = db.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    DepartmentName = x.Department.Name,
                    x.Salary
                })
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext db)
        {
            var sb = new StringBuilder();
            var newAddress = new Address() { AddressText = "Vitoshka 15", TownId = 4};
            var nakov = db.Employees.First(e => e.LastName == "Nakov");

            nakov.Address = newAddress;

            db.SaveChanges();

            var employees = db.Employees
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .Select(e => new
                {
                    e.Address.AddressText
                })
                .ToList();

            employees.ForEach(x => sb.AppendLine(x.AddressText));

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var content = new StringBuilder();

            string pattern = "SA";
            var employeesByNamePattern = context.Employees
                .Where(employee => employee.FirstName.StartsWith(pattern));

            foreach (var employeeByPattern in employeesByNamePattern)
            {
                content.AppendLine($"{employeeByPattern.FirstName} {employeeByPattern.LastName} " +
                                $"- {employeeByPattern.JobTitle} - (${employeeByPattern.Salary})");
            }

            return content.ToString().TrimEnd();
        }
    }
}