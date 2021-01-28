using System;
using System.Collections.Generic;
using System.Linq;

namespace TrojanInvasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int waveCount = int.Parse(Console.ReadLine());

            var platesInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var plates = new Queue<int>(platesInput);
            var warriors = new Stack<int>();

            for (int i = 0; i < waveCount; i++)
            {
                var currentWave = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (i % 3 == 0)
                {
                    plates.Enqueue(currentWave[0]);
                }
                else
                {
                    foreach (var war in currentWave)
                    {
                        warriors.Push(war);
                    }
                }
            }

            var warrior = warriors.Pop();
            var plate = plates.Dequeue();

            while (warriors.Any() && plates.Any())
            {
                int temp = 0;
                if (warrior > plate)
                {
                    while (warrior > 0)
                    {
                        temp = warrior;
                        warrior -= plate;
                        plate -= temp;
                        if (plate <= 0)
                        {
                            plate = plates.Dequeue();
                            break;
                        }
                    }
                }
                else if (plate > warrior)
                {
                    while (plate > 0)
                    {
                        temp = plate;
                        plate -= warrior;
                        warrior -= temp;
                        if (warrior <= 0)
                        {
                            warrior = warriors.Pop();
                            break;
                        }
                    }
                }
                else if (warrior == plate)
                {
                    warrior = warriors.Pop();
                    plate = plates.Dequeue();
                }
            }

            if (plates.Any())
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(' ', plates)}");
            }
            else if (warriors.Any())
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(' ', warriors)}");
            }
        }
    }
}
