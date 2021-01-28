using System;

namespace SoftUni_Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            string weather = "unknown";

            if (n == "sunny")
                weather = "It's warm outside!";
            else
                weather = "It's cold outside!";

            Console.WriteLine(weather);
        }
    }
}
