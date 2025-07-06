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
    public class RoleController : ControllerBase
    {
        private readonly DataContext _context;

        public RoleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Role>>> GetAllRoles()
        {
            var roles = await _context.Roles.ToListAsync();

            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role is null) return NotFound("Role not found.");

            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<List<Role>>> AddSRole(RoleDto roleDto)
        {
            var role = new Role
            {
                RoleName = roleDto.RoleName,
            };

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return Ok(await _context.Roles.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Role>>> UpdateRole(Role updatedRole)
        {
            var dbRole = await _context.Roles.FindAsync(updatedRole.Id);

            if (dbRole is null) return NotFound("Role not found.");

            dbRole.RoleName = updatedRole.RoleName;

            await _context.SaveChangesAsync();

            return Ok(await _context.Roles.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Role>>> DeleteRole(int id)
        {
            var dbRole = await _context.Roles.FindAsync(id);

            if (dbRole is null) return NotFound("Role not found.");

            _context.Roles.Remove(dbRole);
            await _context.SaveChangesAsync();

            return Ok(await _context.Roles.ToListAsync());
        }
    }
}
