using System;

namespace ClassBoxData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(lenght, width, height);

                Console.WriteLine($"Surface Area - {box.CalcArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.CalcLiteralArea():F2}");
                Console.WriteLine($"Volume - {box.CalcVolume():F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
