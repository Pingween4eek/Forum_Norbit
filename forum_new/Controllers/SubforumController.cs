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
    public class SubforumController : ControllerBase
    {
        private readonly DataContext _context;

        public SubforumController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subforum>>> GetAllSubforum()
        {
            var subforums = await _context.Subforums.ToListAsync();

            return Ok(subforums);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subforum>> GetSubforum(int id)
        {
            var subforum = await _context.Subforums.FindAsync(id);

            if (subforum is null) return NotFound("Subforum not found.");

            return Ok(subforum);
        }

        [HttpPost]
        public async Task<ActionResult<List<Subforum>>> AddSubforum(SubforumDto subforumDto)
        {
            var subforum = new Subforum
            {
                Name = subforumDto.Name,
                Description = subforumDto.Description
            };

            _context.Subforums.Add(subforum);
            await _context.SaveChangesAsync();

            return Ok(await _context.Subforums.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Subforum>>> UpdateVSubforum(Subforum updatedSubforum)
        {
            var dbSubforum = await _context.Subforums.FindAsync(updatedSubforum.Id);

            if (dbSubforum is null) return NotFound("Subforum not found.");

            dbSubforum.Name = updatedSubforum.Name;
            dbSubforum.Description = updatedSubforum.Description;

            await _context.SaveChangesAsync();

            return Ok(await _context.Subforums.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Subforum>>> DeleteSubforum(int id)
        {
            var dbSubforum = await _context.Subforums.FindAsync(id);

            if (dbSubforum is null) return NotFound("Subforum not found.");

            _context.Subforums.Remove(dbSubforum);
            await _context.SaveChangesAsync();

            return Ok(await _context.Subforums.ToListAsync());
        }
    }
}
