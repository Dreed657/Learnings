using System;

namespace Pb_May_While_Loop_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string wantedBook = Console.ReadLine();
            int libraryCapacity = int.Parse(Console.ReadLine());
            string currentBook = string.Empty;
            bool itsFinded = false;
            int bookCount = 1;

            while (bookCount <= libraryCapacity)
            {
                currentBook = Console.ReadLine();

                if (currentBook == wantedBook)
                {
                    itsFinded = true;
                    break;
                }

                bookCount++;
            }

            if(itsFinded)
            {
                Console.WriteLine($"You checked {--bookCount} books and found it.");
            }
            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {--bookCount} books.");
            }
        }
    }
}
