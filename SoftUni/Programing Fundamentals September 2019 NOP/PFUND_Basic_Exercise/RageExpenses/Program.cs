using System;

namespace RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int gamesLost = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int BrokenHeadsetsCount = 0;
            int BrokenMousesCount = 0;
            int BrokenKeyboardCount = 0;
            int BrokenDisplaysCount = 0;

            int gamesPlayed = 0;
            int gamesPlayed2 = 0;
            int gamesPlayed3 = 0;

            bool HeadsetIsBroken = false;
            bool MouseIsBroken = false;

            for (int i = 0; i < gamesLost; i++)
            {
                gamesPlayed++;
                gamesPlayed2++;
                gamesPlayed3++;

                if (gamesPlayed == 2)
                {
                    BrokenHeadsetsCount++;
                    HeadsetIsBroken = true;
                    gamesPlayed = 0;
                }
                if (gamesPlayed2 == 3)
                {
                    BrokenMousesCount++;
                    MouseIsBroken = true;
                    gamesPlayed2 = 0;
                }
                if (HeadsetIsBroken && MouseIsBroken)
                {
                    BrokenKeyboardCount++;
                    gamesPlayed3 = 0;
                    if (BrokenKeyboardCount % 2 == 0)
                    {
                        BrokenDisplaysCount++;
                    }
                }
                HeadsetIsBroken = false;
                MouseIsBroken = false;
            }

            double expenses = 
                BrokenDisplaysCount * displayPrice 
                + BrokenHeadsetsCount * headsetPrice 
                + BrokenKeyboardCount * keyboardPrice 
                + BrokenMousesCount * mousePrice; 

            Console.WriteLine($"Rage expenses: {expenses:F2} lv.");
        }
    }
}
