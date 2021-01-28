using System;

namespace Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double shipWidth = double.Parse(Console.ReadLine());
            double shipLenght = double.Parse(Console.ReadLine());
            double shipHeight = double.Parse(Console.ReadLine());
            double avgHeightAstronausts = double.Parse(Console.ReadLine());

            double shipArea = shipWidth * shipLenght * shipHeight;
            double roomArea = (avgHeightAstronausts + 0.40) * 2 * 2;

            double maxAstroniers = Math.Floor(shipArea / roomArea);

            if (maxAstroniers >= 3 && maxAstroniers <= 10)
                Console.WriteLine($"The spacecraft holds {maxAstroniers} astronauts.");
            else if (maxAstroniers < 3)
                Console.WriteLine("The spacecraft is too small.");
            else if (maxAstroniers > 10)
                Console.WriteLine("The spacecraft is too big.");
        }
    }
}
