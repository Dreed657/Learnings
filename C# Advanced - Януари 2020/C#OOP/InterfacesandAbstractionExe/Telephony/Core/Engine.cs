using System;

using Telephony.Exceptions;

namespace Telephony.Core
{
    public static class Engine
    {
        public static void Run()
        {
            var phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var sitesUrls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            CallNumbers(phoneNumbers, smartphone, stationaryPhone);
            VisitSites(sitesUrls, smartphone);
        }

        private static void CallNumbers(string[] phoneNumbers, Smartphone smartphone, StationaryPhone stationaryPhone)
        {
            try
            {
                foreach (var phone in phoneNumbers)
                {
                    if (phone.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(phone));
                    }
                    else if (phone.Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(phone));
                    }
                    else
                    {
                        throw new InvalidNumberException();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void VisitSites(string[] sitesUrls, Smartphone smartphone)
        {
            foreach (var url in sitesUrls)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
