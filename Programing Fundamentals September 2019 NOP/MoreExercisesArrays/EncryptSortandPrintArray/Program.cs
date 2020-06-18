using System;

namespace EncryptSortandPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] namesInNum = new int[n];

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                int sum = 0;
                foreach (char letter in name)
                {
                    if ("aeiouAEIOU".IndexOf(letter) >= 0)
                    {
                        sum += (int)letter * name.Length;
                    }
                    else
                    {
                        sum += (int)letter / name.Length;
                    }
                }
                namesInNum[i] = sum;
                sum = 0;
            }
            Array.Sort(namesInNum);
            foreach (var item in namesInNum)
            {
                Console.WriteLine(item);
            }
        }
    }
}
