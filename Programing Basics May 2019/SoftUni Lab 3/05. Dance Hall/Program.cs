using System;

namespace _05._Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            double L = double.Parse(Console.ReadLine());
            double W = double.Parse(Console.ReadLine());
            double A = double.Parse(Console.ReadLine());
   
            double roomSize = (L * 100) * (W * 100);
            double dresserSize = (A * 100) * (A * 100);
            double benchSize = roomSize / 10;
            double dancerRoomNeeded = 7000 + 40;
            double emptyRoom = roomSize - dresserSize - benchSize;
            double dancerCount = emptyRoom / dancerRoomNeeded;

            Console.WriteLine(Math.Floor(dancerCount));
        }
    }
}

