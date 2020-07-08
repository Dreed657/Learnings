using System;
using System.Linq;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkingLot = new HashSet<string>();

            while (true)
            {
                var tokens = Console.ReadLine().Split(", ");
                if (tokens[0] == "END") break;

                switch (tokens[0])
                {
                    case "IN": parkingLot.Add(tokens[1]); break;
                    case "OUT": parkingLot.Remove(tokens[1]); break;
                }
            }

            if (parkingLot.Any()) foreach (var item in parkingLot) Console.WriteLine(item);
            else Console.WriteLine("Parking Lot is Empty");
        }
    }
}
