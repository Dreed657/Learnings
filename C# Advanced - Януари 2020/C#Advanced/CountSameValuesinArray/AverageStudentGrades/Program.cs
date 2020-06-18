using System;
using System.Linq;
using System.Collections.Generic;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var studentRecord = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                string key = input[0];
                decimal value = decimal.Parse(input[1]);

                if (!studentRecord.ContainsKey(key))
                {
                    studentRecord.Add(key, new List<decimal>());
                }
                studentRecord[input[0]].Add(value);
            }

            foreach (var (key, value) in studentRecord)
            {
                Console.WriteLine($"{key} -> {string.Join(" ", value):F2} (avg: {value.Average():F2})");
            }
        }
    }
}
