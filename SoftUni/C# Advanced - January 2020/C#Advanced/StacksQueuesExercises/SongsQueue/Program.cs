using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var queue = new Queue<string>(input);
            bool noMoreSongs = false;

            while (true)
            {
                var tokens = Console.ReadLine().Split().ToList();

                switch (tokens[0])
                {
                    case "Add":
                        tokens.RemoveAt(0);
                        string name = string.Join(" ", tokens);
                        
                        if (!queue.Contains(name)) queue.Enqueue(name);
                        else Console.WriteLine($"{name} is already contained!");
                        break;
                    case "Play":
                        if (queue.Any()) queue.Dequeue();
                        else noMoreSongs = true;
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", queue));
                        break;
                    default: break;
                }

                if (noMoreSongs || !queue.Any())
                {
                    Console.WriteLine("No more songs!");
                    break;
                }
            }
        }
    }
}
