using System;
using System.Collections.Generic;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rowOne = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] rowTwo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] simulatity = new string[rowTwo.Length + rowTwo.Length];

 

            for (int i = 0; i < rowTwo.Length; i++)
            {
                for (int j = 0; j < rowOne.Length; j++)
                {
                   if (rowOne[j] == rowTwo[i])
                    {
                        simulatity[i] = rowOne[j];
                    }
                }
            }

            List<string> result = new List<string>();

            for (int i = 0; i < simulatity.Length; i++)
            {
                if (simulatity[i] != null)
                {
                    result.Add(simulatity[i]);
                } 
            }


            Console.WriteLine(string.Join(" ", result));
        }
    }
}
