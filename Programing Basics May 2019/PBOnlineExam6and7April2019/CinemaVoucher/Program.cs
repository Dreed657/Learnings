using System;

namespace CinemaVoucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int voucherAmount = int.Parse(Console.ReadLine());
            int ticketCount = 0;
            int otherThings = 0;

            int sum1 = 0;
            int index1 = 0;

            int sum2 = 0;
            int index2 = 0;


            while (true)
            {
                string movieName = Console.ReadLine();
                if (movieName == "End") break;

                if (movieName.Length > 8)
                {
                    foreach (int letter in movieName)
                    {
                        sum1 += letter;
                        index1++;
                        if (index1 == 2) break;
                    }
                    index1 = 0;
                    if (!(voucherAmount < sum1)) ticketCount++;
                }
                else
                {
                    foreach (int letter in movieName)
                    {
                        sum2 += letter;
                        index2++;
                        if (index2 == 1) break;
                    }
                    index2 = 0;
                    if (!(voucherAmount < sum2)) otherThings++;
                }
                int totalSum = sum1 + sum2;
                voucherAmount -= totalSum;
                sum1 = 0;
                sum2 = 0;

                if (voucherAmount <= 0) break;
            }
            Console.WriteLine(ticketCount);
            Console.WriteLine(otherThings);
        }
    }
}
