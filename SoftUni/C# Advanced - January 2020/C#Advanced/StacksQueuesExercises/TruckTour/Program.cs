using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());

            Queue<int> difference = new Queue<int>();

            for (int i = 0; i < pumpsCount; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int amountOfPetrol = numbers[0];
                int distance = numbers[1];

                difference.Enqueue(amountOfPetrol - distance);
            }

            int index = 0;

            while (true)
            {
                Queue<int> copyDifference = new Queue<int>(difference);
                int fuel = -1;

                while (copyDifference.Any())
                {
                    if (copyDifference.Peek() > 0 && fuel == -1)
                    {
                        fuel = copyDifference.Dequeue();
                        difference.Enqueue(difference.Dequeue()); // променяме началото, защото това може да не е началната точка
                    }
                    else if (copyDifference.Peek() < 0 && fuel == -1)
                    {
                        copyDifference.Enqueue(copyDifference.Dequeue()); // поставяме елемента да се върти наново
                        difference.Enqueue(difference.Dequeue());
                        index++; // не е предния елемент така,че вдигаме броята и преминаваме към следващия елемент
                    }
                    else
                    {
                        fuel += copyDifference.Dequeue();
                        if (fuel < 0)
                        {
                            break;
                        }
                    }
                }

                if (fuel >= 0)
                {
                    Console.WriteLine(index);
                    return;
                }

                index++;
            }
        }
    }
}