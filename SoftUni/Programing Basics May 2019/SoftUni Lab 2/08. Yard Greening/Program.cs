using System;

namespace _08._Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            double sqrMeter = double.Parse(Console.ReadLine());
            double price = sqrMeter * 7.61;
            double discoutedPercent = 0.18 * price;
            double discoutedPrice = price - discoutedPercent;

            Console.WriteLine("The final price is: {0:F2} lv.", discoutedPrice);
            Console.WriteLine("The discount is: {0:F2} lv.", discoutedPercent);
        }
    }
}
