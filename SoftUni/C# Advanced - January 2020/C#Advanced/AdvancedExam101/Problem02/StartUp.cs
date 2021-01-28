using System;

namespace Problem02
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int countCommands = int.Parse(Console.ReadLine());

            var matrix = new char[size, size];

            int playerX = 0;
            int playerY = 0;

            bool playerWon = false;

            for (int r = 0; r < size; r++)
            {
                var line = Console.ReadLine().ToCharArray();

                for (int c = 0; c < size; c++)
                {
                    var curElemnet = line[c];
                    if (curElemnet == 'f')
                    {
                        playerX = r;
                        playerY = c;
                    }
                    matrix[r, c] = curElemnet;
                }
            }

            for (int i = 0; i < countCommands; i++)
            {
                var direction = Console.ReadLine();
                if (playerWon) break;

                matrix[playerX, playerY] = '-';

                switch (direction)
                {
                    case "up":
                        playerX--;
                        break;
                    case "down":
                        playerX++;
                        break;
                    case "left":
                        playerY--;
                        break;
                    case "right":
                        playerY++;
                        break;
                }

                if (playerX <= 0)
                {
                    playerX = size - 1;
                }
                else if (playerX > size)
                {
                    playerX = 0;
                }

                if (playerY <= 0)
                {
                    playerY = size - 1;
                }
                else if (playerY > size)
                {
                    playerY = 0;
                }

                var next = matrix[playerX, playerY];

                if (next == 'B')
                {
                    switch (direction)
                    {
                        case "up":
                            playerX--;
                            break;
                        case "down":
                            playerX++;
                            break;
                        case "left":
                            playerY--;
                            break;
                        case "right":
                            playerY++;
                            break;
                    }
                }
                else if (next == 'T')
                {
                    switch (direction)
                    {
                        case "up":
                            playerX++;
                            break;
                        case "down":
                            playerX--;
                            break;
                        case "left":
                            playerY++;
                            break;
                        case "right":
                            playerY--;
                            break;
                    }
                }

                if (playerX <= 0)
                {
                    playerX = size - 1;
                }
                else if (playerX > size)
                {
                    playerX = 0;
                }

                if (playerY <= 0)
                {
                    playerY = size - 1;
                }
                else if (playerY > size)
                {
                    playerY = 0;
                }

                if (matrix[playerX, playerY] == 'F')
                {
                    playerWon = true;
                    break;
                }
            }

            matrix[playerX, playerY] = 'f';

            if (playerWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}