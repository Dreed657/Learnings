using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem01
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lootBox1 = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            var lootBox2 = new Stack<int>(
                Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray());

            var colledtedItems = new List<int>();

            while (lootBox1.Any() && lootBox2.Any())
            {
                var firstNum = lootBox1.Peek();
                var secNum = lootBox2.Peek();

                var sum = firstNum + secNum;
                if (sum % 2 == 0)
                {
                    colledtedItems.Add(sum);
                    lootBox1.Dequeue();
                    lootBox2.Pop();
                }
                else
                {
                    lootBox1.Enqueue(lootBox2.Pop());
                }
            }

            if (!lootBox1.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            
            if (!lootBox2.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (colledtedItems.Sum() > 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {colledtedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {colledtedItems.Sum()}");
            }
        }
    }
}
