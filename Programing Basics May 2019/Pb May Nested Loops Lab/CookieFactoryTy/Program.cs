using System;

namespace CookieFactoryTy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int bakeCount = 0;
            int realBake = 0;
            int moreIngrediants = 0;
            bool flour = false;
            bool eggs = false;
            bool sugar = false;

            for (int i = 0; i < n; i++)
            {
                while (true)
                {
                    string ingredient = Console.ReadLine();

                    if (ingredient == "flour")
                        flour = true;
                    if (ingredient == "eggs")
                        eggs = true;
                    if (ingredient == "sugar")
                        sugar = true;

                    if (ingredient == "Bake!")
                    {
                        realBake++;
                        if (flour && eggs && sugar)
                            bakeCount++;
                        else if (flour == false && eggs == false && sugar == false)
                        {
                            moreIngrediants = bakeCount - realBake;
                        }
                    }
                    if (bakeCount >= n) break;
                }
            }

            for (int i = 0; i < moreIngrediants; i++)
            {
                Console.WriteLine($"The batter should contain flour, eggs and sugar!");

            }

            for (int i = 1; i <= bakeCount; i++)
            {
                Console.WriteLine($"Baking batch number {i}...");
            }
        }
    }
}
