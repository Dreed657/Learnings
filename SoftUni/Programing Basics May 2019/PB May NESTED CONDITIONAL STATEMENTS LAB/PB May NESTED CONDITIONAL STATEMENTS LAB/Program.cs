using System;

namespace PB_May_NESTED_CONDITIONAL_STATEMENTS_LAB
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();

            if (age >= 16) { 
                if (gender == "m")
                    Console.WriteLine("Mr.");
                else if (gender == "f")
                    Console.WriteLine("Ms.");
            }
            else if (age < 16) { 
                 if (gender == "m")
                    Console.WriteLine("Master");
                else if (gender == "f")
                    Console.WriteLine("Miss");
            }
        }
    }
}
