using System;
using System.Collections.Generic;
using System.Linq;

namespace a10._Radioactive_Mutant_Vampire_Bunnies
{
    struct Position
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public Position(Position anotherPosition)
            : this(anotherPosition.Row, anotherPosition.Col)
        {
        }

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public override string ToString()
        {
            return this.Row + " " + this.Col;
        }
    }

    class StartUp
    {
        static void Main(string[] args)
        {
            int[] dimension = IntParseArray();
            int rows = dimension[0];
            int cols = dimension[1];
            char[,] matrix = new char[rows, cols];
            Position playerCurrPosition = new Position();
            List<Position> bunniesCordinates = new List<Position>();
            // bunniesMatrix - same size but bool[,] -> true for bunnny

            //Read Matrix
            for (int row = 0; row < rows; row++)
            {
                char[] currInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currInput[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerCurrPosition = new Position(row, col);
                    }
                    else if (matrix[row, col] == 'B')
                    {
                        bunniesCordinates.Add(new Position(row, col));
                    }
                }
            }

            char[] moves = Console.ReadLine().ToCharArray();

            Position playerNextPosition = new Position(playerCurrPosition);
            bool hasWon = false;
            bool hasDied = false;

            foreach (char move in moves)
            {
                if (hasWon || hasDied)
                {
                    break;
                }

                matrix[playerCurrPosition.Row, playerCurrPosition.Col] = '.';
                switch (move)
                {
                    case 'U':
                        playerNextPosition.Row--;
                        break;
                    case 'D':
                        playerNextPosition.Row++;
                        break;
                    case 'L':
                        playerNextPosition.Col--;
                        break;
                    case 'R':
                        playerNextPosition.Col++;
                        break;
                }

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            if (SpreadBunny(matrix, row, col)) hasDied = true;
                        }
                    }
                }

                hasWon = !IsInMatrix(matrix, playerNextPosition);
                hasDied = !hasWon && IsSymbol(matrix, 'B', playerNextPosition.Row, playerNextPosition.Col);
                if (!hasWon && !hasDied)
                {
                    matrix[playerNextPosition.Row, playerNextPosition.Col] = 'P';
                }

                //List<Position> newBunnies = new List<Position>();
                //foreach (var position in bunniesCordinates)
                //{
                //    int bunyRow = position.Row;
                //    int bunyCol = position.Col;

                //    bool hasDiedFromCurrentSpread = SpreadBunny(matrix, bunyRow, bunyCol);
                //    hasDied = hasDied || hasDiedFromCurrentSpread;
                //}
                //bunniesCordinates.AddRange(newBunnies);

                if (!hasWon)
                {
                    playerCurrPosition = playerNextPosition;
                }
            }

            if (hasWon)
            {
                PrintMatrix(rows, cols, matrix);
                Console.WriteLine($"won: {playerCurrPosition}");
            }
            else if (hasDied)
            {
                PrintMatrix(rows, cols, matrix);
                Console.WriteLine($"dead: {playerNextPosition}");
            }
            else
            {
                throw new InvalidOperationException("Invalid judge");
            }
        }

        static bool SpreadBunny(char[,] matrix, int row, int col)
        {
            bool isTopKillingThePlayer = SetBunny(matrix, row - 1, col);
            bool isBotKillingThePlayer = SetBunny(matrix, row + 1, col);
            bool isLeftKillingThePlayer = SetBunny(matrix, row, col - 1);
            bool isRightKillingThePlayer = SetBunny(matrix, row, col + 1);

            return isTopKillingThePlayer || isBotKillingThePlayer || isLeftKillingThePlayer || isRightKillingThePlayer;
        }

        /// <summary>
        /// Sets the bunny and returns if the player was killed
        /// </summary>
        /// <param name="matrix">The current state of the matrix</param>
        /// <param name="row">Target row where the bunny should be placed</param>
        /// <param name="col">Target col where the bunny should be placed</param>
        /// <returns>True, if the player was killed, otherwise false</returns>
        static bool SetBunny(char[,] matrix, int row, int col)
        {
            bool isKilled = false;
            if (IsInMatrix(matrix, row, col))
            {
                if (matrix[row, col] == 'P')
                {
                    isKilled = true;
                }

                matrix[row, col] = 'B';
            }
            else throw new Exception("OUT OF MATRIX!");

            return isKilled;
        }

        static bool IsSymbol(char[,] matrix, char symbol, int row, int col)
        {
            bool isSymbol = false;

            if (IsInMatrix(matrix, row, col) && matrix[row, col] == symbol)
            {
                isSymbol = true;
            }

            return isSymbol;
        }

        private static int[] IntParseArray()
        {
            return Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
        }



        // COPIED AND WORKING


        static bool IsInMatrix<T>(T[,] matrix, int row, int col)
        {
            bool isInMatrix = true;
            if (row < 0)
            {
                isInMatrix = false;
            }
            else if (row >= matrix.GetLength(0))
            {
                isInMatrix = false;
            }
            else if (col >= matrix.GetLength(1))
            {
                isInMatrix = false;
            }
            else if (col < 0)
            {
                isInMatrix = false;
            }

            return isInMatrix;
        }
        static bool IsInMatrix<T>(T[,] matrix, Position position)
        {
            return IsInMatrix(matrix, position.Row, position.Col);
        }


        private static void PrintMatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}