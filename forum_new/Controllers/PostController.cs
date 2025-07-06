using forum_new.Data;
using forum_new.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace forum_new.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly DataContext _context;

        public PostController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAllPosts()
        {
            var posts = await _context.Posts.ToListAsync();

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post is null) return NotFound("Post not found.");

            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<List<Post>>> AddPost(PostDto postDto)
        {
            var post = new Post
            {
                Title = postDto.Title,
                Content = postDto.Content,
                CreationDate = postDto.CreationDate,
                AuthorId = postDto.AuthorId,
                Rating = postDto.Rating,
                SubforumId = postDto.SubforumId

            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return Ok(await _context.Posts.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Post>>> UpdatePost(Post updatedPost)
        {
            var dbPost = await _context.Posts.FindAsync(updatedPost.Id);

            if (dbPost is null) return NotFound("Post not found.");

            dbPost.Title = updatedPost.Title;
            dbPost.Content = updatedPost.Content;
            dbPost.CreationDate = updatedPost.CreationDate;
            dbPost.AuthorId = updatedPost.AuthorId;
            dbPost.Rating = updatedPost.Rating;
            dbPost.SubforumId = updatedPost.SubforumId;

            await _context.SaveChangesAsync();

            return Ok(await _context.Posts.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Post>>> DeletePost(int id)
        {
            var dbPost = await _context.Posts.FindAsync(id);

            if (dbPost is null) return NotFound("Post not found.");

            _context.Posts.Remove(dbPost);
            await _context.SaveChangesAsync();

            return Ok(await _context.Posts.ToListAsync());
        }
    }
}
