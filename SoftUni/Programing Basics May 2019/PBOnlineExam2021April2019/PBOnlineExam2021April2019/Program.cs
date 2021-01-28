using System;

namespace PBOnlineExam2021April2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int kuzonakCount = int.Parse(Console.ReadLine());
            int eggCartonsCount = int.Parse(Console.ReadLine());
            int kiloCookies = int.Parse(Console.ReadLine());

            double kuzonakPrice = kuzonakCount * 3.20;
            double eggPastyPrice = eggCartonsCount * 4.35;
            double cookiePrice = kiloCookies * 5.40;
            int eggCount = eggCartonsCount * 12;
            double eggPaintPrice = eggCount * 0.15;

            double sum = kuzonakPrice + eggPastyPrice + cookiePrice + eggPaintPrice;

            Console.WriteLine($"{sum:F2}");
        }
    }
}
