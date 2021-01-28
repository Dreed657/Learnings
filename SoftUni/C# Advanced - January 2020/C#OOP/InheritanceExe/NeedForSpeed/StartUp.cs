namespace NeedForSpeed
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new Motorcycle(25, 100);

            car.Drive(100);

            Console.WriteLine(car.Fuel);
        }
    }
}
