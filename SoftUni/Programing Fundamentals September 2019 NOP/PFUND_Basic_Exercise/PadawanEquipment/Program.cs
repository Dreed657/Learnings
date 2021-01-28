using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightSaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double extraSabers = Math.Ceiling(studentsCount * 0.10);
            double totalSaber = (studentsCount + extraSabers) * lightSaberPrice;

            double freeBelts = Math.Floor((double)studentsCount / 6);
            double totalBelts = (studentsCount - freeBelts) * beltPrice;

            double totalRobe = studentsCount * robePrice;

            double moneyNeeded = totalSaber + totalBelts + totalRobe;

            if ((budget - moneyNeeded) > 0)
                Console.WriteLine($"The money is enough - it would cost {moneyNeeded:F2}lv.");
            else
            {
                double moneyLeft = moneyNeeded - budget;
                Console.WriteLine($"Ivan Cho will need {moneyLeft:F2}lv more.");
            }
        }
    }
}
