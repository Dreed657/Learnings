using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> group = new List<Student>();
            
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                Student person = new Student(tokens[0], tokens[1], double.Parse(tokens[2]));
                group.Add(person);
            }

            group = group.OrderByDescending(x => x.Grade).ToList();

            foreach (var item in group) item.print();
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public void print()
        {
            Console.WriteLine($"{FirstName} {LastName}: {Grade:F2}");
        }
    }
}
