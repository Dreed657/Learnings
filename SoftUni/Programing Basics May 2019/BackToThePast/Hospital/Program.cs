using System;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            int treated = 0;
            int unTreated = 0;

            int currentDoctors = 7;

            for (int i = 1; i <= days; i++)
            {
                if (i % 3 == 0)
                    if (unTreated > treated)
                        currentDoctors++;

                int patients = int.Parse(Console.ReadLine());

                if (patients > currentDoctors)
                {
                    treated += currentDoctors;
                    patients -= currentDoctors;

                    unTreated += patients;
                }
                else
                {
                    treated += patients;
                }
            }

            Console.WriteLine($"Treated patients: {treated}.");
            Console.WriteLine($"Untreated patients: {unTreated}.");
        }
    }
}
