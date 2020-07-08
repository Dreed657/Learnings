using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new BloggingContext();
           
            //db.Add(new Blog { Url = "agefrjrty151236234737uertytruwte" });

            var post = new Post
            {
                Title = "some random title",
                Content = "ashethjwertwerhuerjer",
                BlogId = 10
            };

            var blog = db.Blogs.Any(x => x.BlogId == post.BlogId);

            if (blog) db.Add(post);
            else Console.WriteLine("404 no blog found!");

            db.SaveChanges();
        }

        public class BloggingContext : DbContext
        {
            private const string conStr = @"Server=.;Database=BlogDb;Integrated Security=True";
            
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                options.UseSqlServer(conStr);
            }
        }

        public class Blog
        {
            public int BlogId { get; set; }
            public string Url { get; set; }

            public List<Post> Posts { get; } = new List<Post>();
        }

        public class Post
        {
            public int PostId { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }

            public int BlogId { get; set; }
            public Blog Blog { get; set; }
        }
    }
}
