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
    public class CommentController : ControllerBase
    {
        private readonly DataContext _context;

        public CommentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetAllComments()
        {
            var comments = await _context.Comments.ToListAsync();

            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment is null) return NotFound("Comment not found.");

            return Ok(comment);
        }

        [HttpPost]
        public async Task<ActionResult<List<Comment>>> AddComment(CommentDto commentDto)
        {
            var comment = new Comment
            {
                Content = commentDto.Content,
                CreationDate = commentDto.CreationDate,
                AuthorId = commentDto.AuthorId,
                PostId = commentDto.PostId,
                ParentCommentId = commentDto.ParentCommentId,
                Rating = commentDto.Rating,
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return Ok(await _context.Comments.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Comment>>> UpdateComment(Comment updatedComment)
        {
            var dbComment = await _context.Comments.FindAsync(updatedComment.Id);

            if (dbComment is null) return NotFound("Comment not found.");

            dbComment.Content = updatedComment.Content;
            dbComment.CreationDate = updatedComment.CreationDate;
            dbComment.AuthorId = updatedComment.AuthorId;
            dbComment.PostId = updatedComment.PostId;
            dbComment.ParentCommentId = updatedComment.ParentCommentId;
            dbComment.Rating = updatedComment.Rating;

            await _context.SaveChangesAsync();

            return Ok(await _context.Comments.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Comment>>> DeleteComment(int id)
        {
            var dbComment = await _context.Comments.FindAsync(id);

            if (dbComment is null) return NotFound("Comment not found.");

            _context.Comments.Remove(dbComment);
            await _context.SaveChangesAsync();

            return Ok(await _context.Comments.ToListAsync());
        }
    }
}
