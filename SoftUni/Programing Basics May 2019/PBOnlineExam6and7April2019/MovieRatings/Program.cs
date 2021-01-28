using System;

namespace MovieRatings
{
    class Program
    {
        static void Main(string[] args)
        {
            int moviesCount = int.Parse(Console.ReadLine());

            string bestMovie = string.Empty;
            string wurstMovie = string.Empty;
            double maxRating = double.MinValue;
            double minRating = double.MaxValue;
            double ratingSum = 0;

            for (int i = 0; i < moviesCount; i++)
            {
                string movieName = Console.ReadLine();
                double movieRating = double.Parse(Console.ReadLine());

                if (movieRating > maxRating)
                {
                    maxRating = movieRating;
                    bestMovie = movieName;
                }
                if (movieRating < minRating)
                {
                    minRating = movieRating;
                    wurstMovie = movieName;
                }
                ratingSum += movieRating;
            }

            double avgRating = ratingSum / moviesCount;

            Console.WriteLine($"{bestMovie} is with highest rating: {maxRating:F1}");
            Console.WriteLine($"{wurstMovie} is with lowest rating: {minRating:F1}");
            Console.WriteLine($"Average rating: {avgRating:F1}");
        }
    }
}
