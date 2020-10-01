using System;

namespace Runner
{
    public class Program
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer.Chronometer();

            var command = Console.ReadLine();
            while (command != "exit")
            {
                switch (command)
                {
                    case "start":
                        chronometer.Start();
                        break;
                    case "lap":
                        Console.WriteLine(chronometer.Lap());
                        break;
                    case "laps":
                        Console.WriteLine(chronometer.Laps.Count > 0 ? chronometer.GetLaps() : "Laps: no laps");
                        break;
                    case "time":
                        Console.WriteLine(chronometer.GetTime);
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                    case "stop":
                        chronometer.Stop();
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
