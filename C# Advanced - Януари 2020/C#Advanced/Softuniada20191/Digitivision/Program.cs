using System;
using System.Collections.Generic;
using System.Linq;

namespace Digitivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            double sum = n1 + n2 + n3;

            var nums = new List<int>() { n1, n2, n3 };

            bool digitivision = false;

            for (double i1 = nums.Min(); i1 <= nums.Max(); i1++)
            {
                for (double i2 = nums.Min(); i2 <= nums.Max(); i2++)
                {
                    for (double i3 = nums.Min(); i3 <= nums.Max(); i3++)
                    {
                        double curNum = double.Parse(i1.ToString() + i2.ToString() + i3.ToString());
                        if (curNum.ToString().Contains(n1.ToString()) &&
                            curNum.ToString().Contains(n2.ToString()) &&
                            curNum.ToString().Contains(n3.ToString()))
                        {
                            if (curNum % sum == 0)
                            {
                                Console.WriteLine(curNum);
                                digitivision = true;
                            }
                        }
                    }
                }
            }

            if (digitivision)
            {
                Console.WriteLine("Digitivision successful!");
            }
            else
            {
                Console.WriteLine("No digitivision possible.");
            }
        }
    }
}
