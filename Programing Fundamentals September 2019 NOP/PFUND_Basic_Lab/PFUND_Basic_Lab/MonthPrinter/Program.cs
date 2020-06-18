using System;

namespace MonthPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            int month = int.Parse(Console.ReadLine());
            string currentMonth = string.Empty;

            switch (month)
            {
                case 1: currentMonth = "January"; break;
                case 2: currentMonth = "February"; break;
                case 3: currentMonth = "March"; break;
                case 4: currentMonth = "April"; break;
                case 5: currentMonth = "May"; break;
                case 6: currentMonth = "June"; break;
                case 7: currentMonth = "July"; break;
                case 8: currentMonth = "August"; break;
                case 9: currentMonth = "September"; break;
                case 10: currentMonth = "Octomber"; break;
                case 11: currentMonth = "November"; break;
                case 12: currentMonth = "December"; break;
                default: Console.WriteLine("Error!"); break;
            }

            Console.WriteLine(currentMonth);
        }
    }
}
