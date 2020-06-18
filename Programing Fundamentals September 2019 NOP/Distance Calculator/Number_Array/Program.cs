using System;
using System.Linq;

namespace Number_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int index = 0;
            int value = 0;
            int negativeSum = 0;
            int positiveSum = 0;
            int totalSum = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") { break; }

                string[] realInput = input.Split(" ");
                if (realInput[0] == "Switch")
                {
                    input = realInput[0];
                    index = int.Parse(realInput[1]);
                }
                else if (realInput[0] == "Change")
                {
                    input = realInput[0];
                    index = int.Parse(realInput[1]);
                    value = int.Parse(realInput[2]);
                }

                switch (input)
                {
                    case "Switch":
                        if (index >= numbers.Length - 1 || index < 0) { break; }
                        int switchNumber = numbers[index];
                        numbers[index] *= -1; 
                        break;
                    case "Change":
                        if (index >= numbers.Length - 1 || index < 0) { break; }
                        int changeNumber = numbers[index];
                        numbers[index] = value;
                        break;
                    case "Sum Negative":
                        foreach (int item in numbers)
                            if (item < 0) { negativeSum += item; }
                        Console.WriteLine(negativeSum);
                        break;
                    case "Sum Positive":
                        foreach (int item in numbers)
                            if (item >= 0) { positiveSum += item; }
                        Console.WriteLine(positiveSum);
                        break;
                    case "Sum All":
                        foreach (int item in numbers)
                            totalSum += item;
                        Console.WriteLine(totalSum);
                        break;
                    default: break;
                }
            }

            foreach (int item in numbers)
            {
                if (item >= 0)
                    Console.Write(item + " ");
            }
        }
    }
}
