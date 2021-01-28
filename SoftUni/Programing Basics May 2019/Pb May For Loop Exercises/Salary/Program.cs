using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int browserTabsOpen = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 0; i < browserTabsOpen; i++)
            {
                string webSite = Console.ReadLine();

                switch (webSite)
                {
                    case "Facebook": salary -= 150; break;
                    case "Instagram": salary -= 100; break;
                    case "Reddit": salary -= 50; break;
                    default: break;
                }

                if (salary == 0)
                    break;
            }

            if (salary > 0)
            {
                Console.WriteLine(salary);
            }
            else
            {
                Console.WriteLine("You have lost your salary.");
            }
        }
    }
}
