using System;

namespace Pb_May_For_loop_More_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 24; i++)
            {
                for (int s = 0; s < 60; s++)
                {
                    Console.WriteLine($"{i} : {s}");
                }
            }
        }
    }
}
