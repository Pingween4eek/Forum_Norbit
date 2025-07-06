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
    public class VoteController : ControllerBase
    {
        private readonly DataContext _context;

        public VoteController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vote>>> GetAllVotes()
        {
            var votes = await _context.Votes.ToListAsync();

            return Ok(votes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vote>> GetVote(int id)
        {
            var vote = await _context.Votes.FindAsync(id);

            if (vote is null) return NotFound("Vote not found.");

            return Ok(vote);
        }

        [HttpPost]
        public async Task<ActionResult<List<Vote>>> AddVote(VoteDto voteDto)
        {
            var vote = new Vote
            {
                UserId = voteDto.UserId,
                PostId = voteDto.PostId,
                CommentId = voteDto.CommentId,
                VoteType = voteDto.VoteType,
                VoteDate = voteDto.VoteDate
            };

            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();

            return Ok(await _context.Votes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Vote>>> UpdateVote(Vote updatedVote)
        {
            var dbVote = await _context.Votes.FindAsync(updatedVote.Id);

            if (dbVote is null) return NotFound("Vote not found.");

            dbVote.UserId = updatedVote.UserId;
            dbVote.PostId = updatedVote.PostId;
            dbVote.CommentId = updatedVote.CommentId;
            dbVote.VoteDate = updatedVote.VoteDate;
            dbVote.VoteType = updatedVote.VoteType;

            await _context.SaveChangesAsync();

            return Ok(await _context.Votes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Vote>>> DeleteVote(int id)
        {
            var dbVote = await _context.Votes.FindAsync(id);

            if (dbVote is null) return NotFound("Vote not found.");

            _context.Votes.Remove(dbVote);
            await _context.SaveChangesAsync();

            return Ok(await _context.Votes.ToListAsync());
        }
    }
}
