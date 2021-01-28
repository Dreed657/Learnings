using System;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> printer = (arr) => Console.WriteLine(string.Join(' ', arr));

            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string token = Console.ReadLine();
                if (token == "end") break;
    
                if (token == "print")
                {
                    printer(input);
                }
                else
                {
                    var processor = GetProcessor(token);
                    
                    processor(input);
                }
            }
        }

        static Func<int[], int[]> GetProcessor(string filter)
        {
            Func<int[], int[]> processor = filter switch
            {
                "add" => processor = (arr) => 
                    {
                        for (int i = 0; i < arr.Length; i++)
                        {
                            arr[i]++;
                        }
                        
                        return arr;
                    },
                "subtract" => processor = (arr) =>
                        {
                            for (int i = 0; i < arr.Length; i++)
                            {
                                arr[i]--;
                            }

                            return arr;
                        }
                ,
                "multiply" => processor = (arr) =>
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] *= 2;
                    }

                    return arr;
                }
                ,
                _ => null
            };

            return processor;
        }
    }
}
