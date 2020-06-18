using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Cookie_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int bakeCount = 0;
            int moreIngrediants = 0;

            bool flour = false;
            bool eggs = false;
            bool sugar = false;

            while (true)
            {
                string ingridients = Console.ReadLine();

                if (ingridients == "flour") flour = true;
                if (ingridients == "eggs") eggs = true;
                if (ingridients == "sugar") sugar = true;

                if (ingridients == "Bake!")
                {
                    if (flour == false || eggs == false || sugar == false)
                        moreIngrediants++;
                    else if (flour == true && eggs == true && sugar == true)
                    {
                        flour = false;
                        eggs = false;
                        sugar = false;
                        bakeCount++;
                    }
                }
                if (bakeCount == n)
                    break;
            }

            for (int i = 0; i < moreIngrediants; i++)
            {
                Console.WriteLine("The batter should contain flour, eggs and sugar!");
            }

            for (int h = 0; h < bakeCount; h++)
            {
                Console.WriteLine($"Baking batch number {h + 1}...");
            }
        }
    }
}