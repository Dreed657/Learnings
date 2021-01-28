using System;

namespace FootballLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            double stadionCapacity = int.Parse(Console.ReadLine());
            double allFans = int.Parse(Console.ReadLine());

            double sectorA = 0;
            double sectorB = 0;
            double sectorV = 0;
            double sectorG = 0;

            for (int i = 0; i < allFans; i++)
            {
                string sector = Console.ReadLine();

                switch (sector)
                {
                    case "A": sectorA++; break;
                    case "B": sectorB++; break;
                    case "V": sectorV++; break;
                    case "G": sectorG++; break;
                    default:
                        break;
                }
            }

            double pA = (sectorA / allFans) * 100;
            double pB = (sectorB / allFans) * 100;
            double pV = (sectorV / allFans) * 100;
            double pG = (sectorG / allFans) * 100;
            double pAll = (allFans / stadionCapacity) * 100;

            Console.WriteLine($"{pA:F2}%");
            Console.WriteLine($"{pB:F2}%");
            Console.WriteLine($"{pV:F2}%");
            Console.WriteLine($"{pG:F2}%");
            Console.WriteLine($"{pAll:F2}%");
        }
    }
}
