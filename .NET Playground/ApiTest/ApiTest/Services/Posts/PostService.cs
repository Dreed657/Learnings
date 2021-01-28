using System.Collections.Generic;
using System.Threading.Tasks;
using ApiTest.Data;
using ApiTest.Data.Models;
using ApiTest.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _db;

        public PostService(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await this._db.Posts.ToListAsync();
        }

        public async Task<Post> GetById(int id)
        {
            return await this._db.Posts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Post> CreatePost(CreatePostInputModel model)
        {
            var post = new Post() {Content = model.Content};

            await this._db.Posts.AddAsync(post);
            await this._db.SaveChangesAsync();

            return post;
        }
    }
}
