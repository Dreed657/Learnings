using System;
using System.Collections.Generic;
using System.Linq;
using Articleing;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> posts = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ");
                Article post = new Article(tokens[0], tokens[1], tokens[2]);
                posts.Add(post);
            }

            string creteria = Console.ReadLine();

            switch (creteria)
            {
                case "title": posts = posts.OrderBy(x => x.Title).ToList(); break;
                case "content":posts = posts.OrderBy(x => x.Content).ToList(); break;
                case "author":posts = posts.OrderBy(x => x.Author).ToList(); break;
            }

            foreach (var item in posts) Console.WriteLine(item.ToString());
        }
    }
}
