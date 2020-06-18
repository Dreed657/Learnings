using System;

namespace OnTimefortheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeOfExam = int.Parse(Console.ReadLine());
            int minutesOfExam = int.Parse(Console.ReadLine());
            int timeOfArrival = int.Parse(Console.ReadLine());
            int minutesOfArrival = int.Parse(Console.ReadLine());

            int totalMinutesExam = (timeOfExam * 60) + minutesOfExam;
            int totalMinutesArrival = (timeOfArrival * 60) + minutesOfArrival;

            int difTime = totalMinutesArrival - totalMinutesExam;

            if (difTime == 0)
            {
                Console.WriteLine("On time");
            }
            else if (difTime < 0)
            {
                // Early
                int rightTime = Math.Abs(difTime);
                int arrivalTimeHour = rightTime / 60;
                int arrivalTimeMinutes = rightTime % 60;

                if (rightTime < 60)
                {
                    if (rightTime <= 30)
                    {
                        Console.WriteLine("On time");
                        Console.WriteLine($"{arrivalTimeMinutes} minutes before the start");
                    }
                    else
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine($"{arrivalTimeMinutes} minutes before the start");
                    }
                }
                else if (rightTime >= 60)
                {
                    if (arrivalTimeMinutes < 10)
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine($"{arrivalTimeHour}:0{arrivalTimeMinutes} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine($"{arrivalTimeHour}:{arrivalTimeMinutes} hours before the start");
                    }
                }
            }
            else if (difTime > 0)
            {
                // Late
                int rightTime = Math.Abs(difTime);
                int arrivalTimeHour = rightTime / 60;
                int arrivalTimeMinutes = rightTime % 60;

                if (rightTime < 60)
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{arrivalTimeMinutes} minutes after the start");
                }
                else if (rightTime >= 60)
                {
                    if (arrivalTimeMinutes < 10)
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine($"{arrivalTimeHour}:0{arrivalTimeMinutes} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine($"{arrivalTimeHour}:{arrivalTimeMinutes} hours after the start");
                    }
                }
            }
        }
    }
}
