using System;

namespace Steps
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsCount = 0;
            int steps = 0;
            int finalSteps = 0;

            while (stepsCount <= 10000) 
            {
                string input = Console.ReadLine();
                if (input != "Going home")
                {
                    steps = int.Parse(input);
                    if (steps < 0)
                    {
                        steps = 0;
                    }
                    stepsCount += steps;
                }
                else
                {
                    int lastInput = int.Parse(Console.ReadLine());
                    stepsCount += lastInput;
                    break;
                }
            }

            if (stepsCount >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
            } 
            else
            {
                finalSteps = 10000 - stepsCount;
                Console.WriteLine($"{finalSteps} more steps to reach goal.");
            }
        }
    }
}
