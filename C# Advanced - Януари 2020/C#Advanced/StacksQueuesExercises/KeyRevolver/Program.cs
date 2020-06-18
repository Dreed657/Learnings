using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceBullet = int.Parse(Console.ReadLine());
            int sizeBarrel = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var locks = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray().Reverse());
            int intelligence = int.Parse(Console.ReadLine());

            int totalBulletsFired = 0;
            int bulletsPuchesed = sizeBarrel;
            int barrel = sizeBarrel;
            int moneyEarned = 0;

            while (true)
            {
                if (locks.Any() && barrel != 0 && bullets.Any())
                {
                    totalBulletsFired++;
                    barrel--;
                    if (bullets.Peek() <= locks.Peek())
                    {
                        Console.WriteLine("Bang!");
                        bullets.Pop();
                        locks.Pop();
                    }
                    else
                    {
                        bullets.Pop();
                        Console.WriteLine("Ping!");
                    }
                }
                else if (bullets.Any() && barrel == 0)
                {
                    Console.WriteLine("Reloading!");
                    bulletsPuchesed += sizeBarrel - barrel;
                    barrel = sizeBarrel;
                }
                else
                {
                    moneyEarned = intelligence - ((bulletsPuchesed - barrel) * priceBullet);
                    break;
                }
            }

            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{barrel} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
