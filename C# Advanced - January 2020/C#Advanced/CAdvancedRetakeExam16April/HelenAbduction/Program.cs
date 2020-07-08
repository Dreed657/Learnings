using System;

namespace HelenAbduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            var field = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                var lineToken = Console.ReadLine().ToCharArray();

                for (int j = 0; j < size; j++)
                {
                    field[i, j] = lineToken[j];
                }
            }

            int[] helenaIndex = new int[2];
            int[] playerIndex = new int[2];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (field[i, j] == 'H')
                    {
                        helenaIndex[0] = i;
                        helenaIndex[1] = j;
                        break;
                    }
                    else if (field[i, j] == 'P')
                    {
                        playerIndex[0] = i;
                        playerIndex[1] = j;
                        break;
                    }
                }
            }
            
            bool backTogether = false;

            while (!backTogether)
            {
                if (energy <= 0) break;
                var tokens = Console.ReadLine().Split();

                var x = int.Parse(tokens[1]);
                var y = int.Parse(tokens[2]);

                field[x, y] = 'S';

                int[] goCords = new int[2];
                var result = 0;
                switch (tokens[0])
                {
                    case "up":
                        goCords = new int[] { playerIndex[0] - 1, playerIndex[1] };
                        result = Move(field, energy, playerIndex, goCords);
                        if (result == 1) backTogether = true;
                        else if (result == 2) energy -= 2;
                        else if (result == 3) energy--;
                        break;
                    case "down":
                        goCords = new int[] { playerIndex[0] + 1, playerIndex[1]};
                        result = Move(field, energy, playerIndex, goCords);
                        if (result == 1) backTogether = true;
                        else if (result == 2) energy -= 2;
                        else if (result == 3) energy--;
                        break;
                    case "left":
                        goCords = new int[] { playerIndex[0], playerIndex[1] - 1 };
                        result = Move(field, energy, playerIndex, goCords);
                        if (result == 1) backTogether = true;
                        else if (result == 2) energy -= 2;
                        else if (result == 3) energy--;
                        break;
                    case "right":
                        goCords = new int[] { playerIndex[0], playerIndex[1] + 1 };
                        result = Move(field, energy, playerIndex, goCords);
                        if (result == 1) backTogether = true;
                        else if (result == 2) energy -= 2;
                        else if (result == 3) energy--;
                        break;
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static int Move(char[,] field, int energy, int[] playerIndex, int[] whereToGo)
        {
            var temp = field[whereToGo[0], whereToGo[1]];

            if (CheckValid(field, whereToGo))
            {
                if (temp == '-')
                {
                    field[whereToGo[0], whereToGo[1]] = field[playerIndex[0], playerIndex[1]];
                    field[playerIndex[0], playerIndex[1]] = temp;
                    return 3;
                }
                else if (temp == 'H')
                {
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                    field[playerIndex[0], playerIndex[1]] = '-';
                    field[whereToGo[0], whereToGo[1]] = '-';
                    return 1;
                }
                else if (temp == 'S')
                {
                    if (energy - 2 >= 2)
                    {
                        Console.WriteLine($"Paris died at {whereToGo[0]};{whereToGo[1]}.");
                        field[playerIndex[0], playerIndex[1]] = '-';
                        field[whereToGo[0], whereToGo[1]] = 'X';
                        return 1;
                    }
                    else
                    {
                        field[whereToGo[0], whereToGo[1]] = field[playerIndex[0], playerIndex[1]];
                        field[playerIndex[0], playerIndex[1]] = temp;
                        return 0;
                    }
                }
            }

            playerIndex[0] = whereToGo[0];
            playerIndex[1] = whereToGo[1];

            return 0;
        }

        public static bool CheckValid(char[,] field, int[] whereToGo)
        {
            var x = whereToGo[0];
            var y = whereToGo[1];

            if (field.GetLength(0) < x && field.GetLength(1) < y && x >= 0 && y >= 0)
                return true;

            return false;
        }
    }
}
