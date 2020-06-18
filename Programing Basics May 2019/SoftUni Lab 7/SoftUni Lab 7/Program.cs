using System;

namespace SoftUni_Lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int poolVolume = int.Parse(Console.ReadLine());
            int p1 = int.Parse(Console.ReadLine());
            int p2 = int.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double pipeOneDebitSum = p1 * h;
            double pipeTwoDebitSum = p2 * h;
            double pipesDebitsSum = pipeOneDebitSum + pipeTwoDebitSum;

            if (pipesDebitsSum < poolVolume)
            {
                double poolFullnessPercent = (pipesDebitsSum / poolVolume) * 100;
                double pipeOneVolume = Math.Round((pipeOneDebitSum / pipesDebitsSum) * 100, 2);
                double pipeTwoVolume = Math.Round((pipeTwoDebitSum / pipesDebitsSum) * 100, 2);
                Console.WriteLine($"The pool is {poolFullnessPercent:F2}% full. Pipe 1: {pipeOneVolume:F2}%. Pipe 2: {pipeTwoVolume:F2}%.");
            }
            else
            {
                double diffVolume = Math.Round(pipesDebitsSum - poolVolume, 2);
                Console.WriteLine($"For {h:F2} hours the pool overflows with {diffVolume:F2} liters.");
            }
        }
    }
}
