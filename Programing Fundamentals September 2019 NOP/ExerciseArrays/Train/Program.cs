using System;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int trainWagenCount = int.Parse(Console.ReadLine());
            int[] passnagers = new int[trainWagenCount];

            for (int i = 0; i < trainWagenCount; i++)
            {
                int wagonPassangers = int.Parse(Console.ReadLine());
                passnagers[i] = wagonPassangers;
            }

            int sum = passnagers.Sum();

            Console.WriteLine(string.Join(" ", passnagers));
            Console.WriteLine(sum);
        }
    }
}
