using System;

namespace _04._Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double value = double.Parse(Console.ReadLine());
            string inputMetric = Console.ReadLine();
            string outputMetric = Console.ReadLine();
            double outputValue = 0.0;

            if (inputMetric == "mm")
            {
                if (outputMetric == "cm")
                    outputValue = value / 10;
                else if (outputMetric == "m")
                    outputValue = value / 1000;
            }   
            else if (inputMetric == "m")
            {
                if (outputMetric == "mm")
                    outputValue = value * 1000;
                else if (outputMetric == "cm")
                    outputValue = value * 100;
            }
            else if (inputMetric == "cm")
            {
                if (outputMetric == "m")
                    outputValue = value / 100;
                else if (outputMetric == "mm")
                    outputValue = value * 10;
            }
             
            outputValue = Math.Round(outputValue, 3);

            Console.WriteLine($"{outputValue:F3}");
        }
    }
}
