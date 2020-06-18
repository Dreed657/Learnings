using System;
using System.Numerics;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            byte multiplier = byte.Parse(Console.ReadLine());

            BigInteger result = n * multiplier;

            Console.WriteLine(result);
        }
    }
}
