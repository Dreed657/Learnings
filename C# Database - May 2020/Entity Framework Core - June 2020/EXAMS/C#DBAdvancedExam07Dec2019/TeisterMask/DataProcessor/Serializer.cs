using System.Globalization;
using System.Linq;
using Cinema.XMLTools;
using Newtonsoft.Json;
using TeisterMask.DataProcessor.ExportDto;

namespace TeisterMask.DataProcessor
{
    using System;
    using Data;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .ToList()
                .Where(x => x.Tasks.Any())
                .Select(x => new ProjectDto
                {
                    TasksCount = x.Tasks.Count,
                    Name = x.Name,
                    HasEndDate = x.DueDate == null ? "No" : "Yes",
                    Tasks = x.Tasks.Select(t => new ExportTaskDto
                        {
                            Name = t.Name,
                            Label = t.LabelType.ToString()
                        })
                        .OrderBy(t => t.Name)
                        .ToArray()
                })
                .OrderByDescending(x => x.Tasks.Length)
                .ThenBy(x => x.Name)
                .ToList();

            return XmlConverter.Serialize(projects, "Projects");
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .ToList()
                .Where(x => x.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .Select(x => new
                {
                    x.Username,
                    Tasks = x.EmployeesTasks
                        .Where(t => t.Task.OpenDate >= date)
                        .OrderByDescending(t => t.Task.DueDate)
                        .ThenBy(t => t.Task.Name)
                        .Select(s => new 
                        {
                            TaskName = s.Task.Name,
                            OpenDate = s.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = s.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = s.Task.LabelType.ToString(),
                            ExecutionType = s.Task.ExecutionType.ToString()
                        })
                        .ToList()
                })
                .OrderByDescending(x => x.Tasks.Count)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }
    }
}