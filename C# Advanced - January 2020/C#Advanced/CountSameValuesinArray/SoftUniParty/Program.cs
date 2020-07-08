using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var reservations = new HashSet<string>();
            var vipReservations = new HashSet<string>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "PARTY") break;

                bool vip = char.IsDigit(input[0]);

                if (vip) vipReservations.Add(input);
                else reservations.Add(input);
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;

                bool vip = char.IsDigit(input[0]);

                if (vip) vipReservations.Remove(input);
                else reservations.Remove(input);
            }

            Console.WriteLine(reservations.Count() + vipReservations.Count);

            if (vipReservations.Any())
                foreach (var item in vipReservations) Console.WriteLine(item);


            if (reservations.Any())
                foreach (var item in reservations) Console.WriteLine(item);
        }
    }
}
