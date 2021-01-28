using System;

namespace EasterEggsBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggCountPlayerOne = int.Parse(Console.ReadLine());
            int eggCountPlayerTwo = int.Parse(Console.ReadLine());

            bool playerOne = false;
            bool playerTwo = false;

            while (true)
            {
                string winner = Console.ReadLine();
                if (winner == "End of battle")
                    break;

                if (winner == "one")
                    eggCountPlayerTwo--;
                else if (winner == "two")
                    eggCountPlayerOne--;

                if (eggCountPlayerOne <= 0)
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {eggCountPlayerTwo} eggs left.");
                    playerOne = true;
                    break;
                }
                else if (eggCountPlayerTwo <= 0)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {eggCountPlayerOne} eggs left.");
                    playerTwo = true;
                    break;
                }
            }
            if (!(playerOne || playerTwo))
            {
                Console.WriteLine($"Player one has {eggCountPlayerOne} eggs left.");
                Console.WriteLine($"Player two has {eggCountPlayerTwo} eggs left.");
            }
        }
    }
}
