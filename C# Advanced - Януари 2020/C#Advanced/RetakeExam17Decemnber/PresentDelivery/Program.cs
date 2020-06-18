using System;
using System.Linq;

namespace PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int presentCount = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int santaX = 0;
            int santaY = 0;

            int niceKids = 0;

            for (int i = 0; i < size; i++)
            {
                char[] line = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(char.Parse)
                        .ToArray();

                for (int j = 0; j < size; j++)
                {
                    if (line[j] == 'S')
                    {
                        santaX = i;
                        santaY = j;
                    }
                    else if (line[j] == 'V')
                    {
                        niceKids++;
                    }
                    matrix[i, j] = line[j];
                }
            }

            while (true)
            {
                matrix[santaX, santaY] = '-';

                string direction = Console.ReadLine();
                if (direction == "Christmas morning") break;

                switch (direction)
                {
                    case "up":
                        santaX -= 1;
                        break;
                    case "down":
                        santaX += 1;
                        break;
                    case "left":
                        santaY -= 1;
                        break;
                    case "right":
                        santaY += 1;
                        break;
                }

                char nextCell = matrix[santaX, santaY];

                if (nextCell == 'V')
                {
                    presentCount--;
                    matrix[santaX, santaY] = '-';
                }
                else if (nextCell == 'X')
                {
                    matrix[santaX, santaY] = 'X';
                }
                else if (nextCell == 'C')
                {
                    char up = matrix[santaX - 1, santaY];
                    char down = matrix[santaX + 1, santaY];
                    char left = matrix[santaX, santaY - 1];
                    char right = matrix[santaX, santaY + 1];

                    if (up == 'X' || up == 'V')
                    {
                        presentCount--;
                        matrix[santaX - 1, santaY] = '-';
                    }
                    if (down == 'X' || down == 'V')
                    {
                        presentCount--;
                        matrix[santaX + 1, santaY] = '-';
                    }
                    if (left == 'X' || left == 'V')
                    {
                        presentCount--;
                        matrix[santaX, santaY - 1] = '-';
                    }
                    if (right == 'X' || right == 'V')
                    {
                        presentCount--;
                        matrix[santaX, santaY + 1] = '-';
                    }
                }

                if (presentCount <= 0)
                {
                    Console.WriteLine("Santa ran out of presents!");
                    break;
                }
            }

            matrix[santaX, santaY] = 'S';

            int kidsLeft = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var curCell = matrix[i, j];
                    if (curCell == 'V') kidsLeft++;

                    Console.Write(curCell + " ");
                }
                Console.WriteLine();
            }

            if (kidsLeft > 0)
            {
                Console.WriteLine($"No presents for {kidsLeft} nice kid/s.");
            }
            else
            {
                Console.WriteLine($"Good job, Santa! {niceKids} happy nice kid/s.");
            }
        }
    }
}
