using System;

namespace StadiumIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            int sectorsStadion = int.Parse(Console.ReadLine());
            int stadionCapacity = int.Parse(Console.ReadLine());
            double priceTicket = double.Parse(Console.ReadLine());

            double incomeSector = (stadionCapacity * priceTicket) / sectorsStadion;
            double income = incomeSector * sectorsStadion;
            double charity = (income - (incomeSector * 0.75)) / 8;

            Console.WriteLine($"Total income - {income:F2} BGN");
            Console.WriteLine($"Money for charity - {charity:F2} BGN");
        }
    }
}
