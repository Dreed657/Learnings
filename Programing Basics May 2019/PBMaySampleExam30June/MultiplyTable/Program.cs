using System;

namespace MultiplyTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string currentDigit = number.ToString();

            for (int i = 1; i <= int.Parse(currentDigit[2].ToString()); i++)
            {
                for (int j = 1; j <= int.Parse(currentDigit[1].ToString()); j++)
                {
                    for (int k = 1; k <= int.Parse(currentDigit[0].ToString()); k++)
                    {
                        Console.WriteLine($"{i} * {j} * {k} = {i * j * k};");
                    }
                }
            }
        }
    }
}
