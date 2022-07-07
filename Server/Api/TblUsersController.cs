using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Model;

namespace Server.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblUsersController : ControllerBase
    {
        private readonly ServerContext _context;

        public TblUsersController(ServerContext context)
        {
            _context = context;
        }

        // GET: api/TblUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUsers>>> GetTblUsers()
        {
            return await _context.TblUsers.ToListAsync();
        }

        // GET: api/TblUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblUsers>> GetTblUsers(int id)
        {
            var tblUsers = await _context.TblUsers.FindAsync(id);

            if (tblUsers == null)
            {
                return NotFound();
            }

            return tblUsers;
        }

        // PUT: api/TblUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUsers(int id, TblUsers tblUsers)
        {
            if (id != tblUsers.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // GET: api/tblUsers/userLogin?name=Name&pw=Password
        [HttpGet("userLogin")]
        public async Task<ActionResult<TblUsers>> UserLogin(string name, string pw)
        {
            var user = await _context.TblUsers.FirstOrDefaultAsync(s => s.Name == name.Trim() && s.Password.Trim() == pw);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        // POST: api/TblUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblUsers>> PostTblUsers(TblUsers tblUsers)
        {
            _context.TblUsers.Add(tblUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblUsers", new { id = tblUsers.Id }, tblUsers);
        }

        // DELETE: api/TblUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblUsers>> DeleteTblUsers(int id)
        {
            var tblUsers = await _context.TblUsers.FindAsync(id);
            if (tblUsers == null)
            {
                return NotFound();
            }

            _context.TblUsers.Remove(tblUsers);
            await _context.SaveChangesAsync();

            return tblUsers;
        }

        private bool TblUsersExists(int id)
        {
            return _context.TblUsers.Any(e => e.Id == id);
        }
    }
}
