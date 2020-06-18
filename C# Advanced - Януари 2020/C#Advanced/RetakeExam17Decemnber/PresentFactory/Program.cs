using System;
using System.Linq;
using System.Collections.Generic;

namespace PresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var boxexOfMaterials = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            var magicLevel = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var boxes = new Stack<int>(boxexOfMaterials);
            var magic = new Queue<int>(magicLevel);

            int presentsCrafted = 0;

            var dict = new Dictionary<string, int>();

            while (boxes.Any() && magic.Any())
            {
                int curBox = boxes.Peek();
                int curMagic = magic.Peek();
                int totalMagicLevel = curBox * curMagic;
                
                if (totalMagicLevel == 150)
                {
                    //Doll
                    presentsCrafted++;
                    if (!dict.ContainsKey("Doll")) dict.Add("Doll", 0);
                    dict["Doll"]++;
                    boxes.Pop();
                    magic.Dequeue();
                }
                else if (totalMagicLevel == 250)
                {
                    //Train
                    presentsCrafted++;
                    if (!dict.ContainsKey("Train")) dict.Add("Train", 0);
                    dict["Train"]++;
                    boxes.Pop();
                    magic.Dequeue();
                }
                else if (totalMagicLevel == 300)
                {
                    //Bear
                    presentsCrafted++;
                    if (!dict.ContainsKey("Teddy bear")) dict.Add("Teddy bear", 0);
                    dict["Teddy bear"]++;
                    boxes.Pop();
                    magic.Dequeue();
                }
                else if (totalMagicLevel == 400)
                {
                    //Bicycle
                    presentsCrafted++;
                    if (!dict.ContainsKey("Bicycle")) dict.Add("Bicycle", 0);
                    dict["Bicycle"]++;
                    boxes.Pop();
                    magic.Dequeue();
                }
                else if (totalMagicLevel < 0)
                {
                    boxes.Pop();
                    magic.Dequeue();
                    boxes.Push(curBox + curMagic);
                }
                else
                {
                    if (curMagic == 0) magic.Dequeue();
                    if (curBox == 0) boxes.Pop();

                    if (totalMagicLevel > 0)
                    {
                        magic.Dequeue();
                        boxes.Push(boxes.Pop() + 15);
                    }
                }
            }

            if ((dict.ContainsKey("Teddy bear") && dict.ContainsKey("Bicycle")) || (dict.ContainsKey("Doll") && dict.ContainsKey("Train")))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (boxes.Any())
            {
                Console.WriteLine($"Materials left: {string.Join(", ", boxes)}");
            }

            if (magic.Any())
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magic)}");
            }

            if (dict.Any())
            {
                foreach (var (key, value) in dict.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"{key}: {value}");
                }
            }
        }
    }
}
