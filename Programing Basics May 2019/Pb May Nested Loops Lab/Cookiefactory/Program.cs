using System;

namespace CookieFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int bakeCount = 0;
            int moreIngrediants = 0;

            for (int i = 0; i < n; i++)
            {
                while (true)
                {
                    string ingredient = Console.ReadLine();
                    bool flour = false;
                    bool eggs = false;
                    bool sugar = false;

                    if (ingredient == "flour")
                        flour = true;
                    if (ingredient == "eggs")
                        eggs = true;
                    if (ingredient == "sugar")
                        sugar = true;

                    if (ingredient == "Bake!")
                    {
                        if (flour == false || eggs == false || sugar == false)
                            moreIngrediants++;
                        else if (flour == true && eggs == true && sugar == true)
                        {
                            bakeCount++;
                        }
                    }

                    if (bakeCount == n) break;
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
