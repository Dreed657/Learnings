using System;
using System.Linq;
using System.Collections.Generic;

namespace CountSameValuesinArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var myDictionary = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!myDictionary.ContainsKey(input[i]))
                {
                    myDictionary.Add(input[i], 1);
                }
                else myDictionary[input[i]]++;
            }

            foreach (var (key, value) in myDictionary)
            {
                Console.WriteLine($"{key} - {value} times");
            }
        }
    }
}
