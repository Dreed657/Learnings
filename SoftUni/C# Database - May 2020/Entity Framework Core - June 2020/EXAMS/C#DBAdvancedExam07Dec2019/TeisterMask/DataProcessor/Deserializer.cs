using System.Globalization;
using System.Linq;
using System.Text;
using Cinema.XMLTools;
using Newtonsoft.Json;
using TeisterMask.Data.Models;
using TeisterMask.Data.Models.Enums;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var projectsResult = XmlConverter.Deserializer<ProjectDto>(xmlString, "Projects");

            var validProjects = new List<Project>();
            var validTasks = new List<Task>();

            foreach (var projectDto in projectsResult)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime projectOpenDate;
                var isProjectOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectOpenDate);

                DateTime? projectDueDate;

                if (!string.IsNullOrEmpty(projectDto.DueDate) && !string.IsNullOrWhiteSpace(projectDto.DueDate))
                {
                    projectDueDate = DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    projectDueDate = null;
                }

                if (!isProjectOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Project validProject = new Project()
                {
                    Name = projectDto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate
                };

                int taskCount = 0;

                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    var isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                    DateTime taskDueDate;
                    var isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    if (!isTaskOpenDateValid || !isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < projectOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskDueDate > projectDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var validTask = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType,
                        Project = validProject
                    };

                    validTasks.Add(validTask);
                    taskCount++;
                }

                validProjects.Add(validProject);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, validProject.Name, taskCount));
            }

            context.Projects.AddRange(validProjects);
            context.Tasks.AddRange(validTasks);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var employeesResult = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);
            var validEmployees = new List<Employee>();
            var validRelationsEmployeeTasks = new List<EmployeeTask>();

            foreach (var employeeDto in employeesResult)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                //var validTasks = employeeDto.Tasks
                //    .Distinct()
                //    .Where(x => IsTaskExists(context, x))
                //    .Select(taskId => context.Tasks.Find(taskId))
                //    .ToList();

                var validTasks = new List<Task>();

                foreach (var taskId in employeeDto.Tasks.Distinct())
                {
                    var task = IsTaskExists(context, taskId);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    validTasks.Add(task);
                }

                validRelationsEmployeeTasks.AddRange(validTasks.Select(validTask => new EmployeeTask {Employee = employee, Task = validTask}));

                validEmployees.Add(employee);

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, validTasks.Count));
            }

            context.Employees.AddRange(validEmployees);
            context.EmployeesTasks.AddRange(validRelationsEmployeeTasks);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static Task IsTaskExists(TeisterMaskContext context, int Id)
        {
            return context.Tasks.Find(Id);
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}