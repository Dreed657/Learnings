using System;

namespace Days_Of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string day = string.Empty;

            switch (n)
            {
                case 1: day = "Monday"; break;
                case 2: day = "Tuesday"; break;
                case 3: day = "Wednesday"; break;
                case 4: day = "Thursday"; break;
                case 5: day = "Friday"; break;
                case 6: day = "Saturday"; break;
                case 7: day = "Sunday"; break;
                default: day = "Invalid day!"; break;
            }

            Console.WriteLine(day);
        }
    }
}
