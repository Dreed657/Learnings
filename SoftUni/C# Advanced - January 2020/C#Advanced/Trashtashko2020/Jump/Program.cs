using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Jump
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var matrix = new int[size[0], size[1]];

            int jumpCount = 0;

            for (int i = 0; i < size[0]; i++)
            {
                var line = Console.ReadLine().ToCharArray();
                for (int j = 0; j < size[1]; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            //S Player
            //- wall can step on in
            //0 empty space

            
        }
    }
}
