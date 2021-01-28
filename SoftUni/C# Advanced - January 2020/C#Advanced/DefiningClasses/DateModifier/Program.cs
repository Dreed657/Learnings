using System;

namespace DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            var date1 = DateTime.Parse(Console.ReadLine());
            var date2 = DateTime.Parse(Console.ReadLine());

            var diff = (date2 - date1).TotalDays;

            Console.WriteLine(Math.Abs(diff));
        }
    }
}
