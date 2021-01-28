using System;

namespace PBOnlineExam28a29July2018
{
    class Program
    {
        static void Main(string[] args)
        {
            int sectorsCount = int.Parse(Console.ReadLine());
            int stadianCapacity = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());

            double incomePerSector = (stadianCapacity * ticketPrice) / sectorsCount;
            double totalIncome = incomePerSector * sectorsCount;
            double charity = (totalIncome - (incomePerSector * 0.75)) / 8;
        
            Console.WriteLine($"Total income - {totalIncome:F2} BGN");
            Console.WriteLine($"Money for charity - {charity:F2} BGN");
        }
    }
}
