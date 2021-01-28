using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiTest.Data.Models;
using ApiTest.Services.Posts;
using ApiTest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            this._postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAll()
        {
            return Ok(await this._postService.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Post), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        public async Task<ActionResult<Post>> GetById(int id)
        {
            var result = await this._postService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(CreatePostInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            try
            {
                var result = await this._postService.CreatePost(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
