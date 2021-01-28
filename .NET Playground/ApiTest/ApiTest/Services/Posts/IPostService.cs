using System.Collections.Generic;
using System.Threading.Tasks;
using ApiTest.Data.Models;
using ApiTest.ViewModels;

namespace ApiTest.Services.Posts
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAll();
        
        Task<Post> GetById(int id);

        Task<Post> CreatePost(CreatePostInputModel model);
    }
}
