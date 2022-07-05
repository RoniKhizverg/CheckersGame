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
    public class TblGamesController : ControllerBase
    {
        private readonly ServerContext _context;

        public TblGamesController(ServerContext context)
        {
            _context = context;
        }

        // GET: api/TblGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblGames>>> GetTblGames()
        {
          if (_context.TblGames == null)
          {
              return NotFound();
          }
            return await _context.TblGames.ToListAsync();
        }

        // GET: api/TblGames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblGames>> GetTblGames(int id)
        {
          if (_context.TblGames == null)
          {
              return NotFound();
          }
            var tblGames = await _context.TblGames.FindAsync(id);

            if (tblGames == null)
            {
                return NotFound();
            }

            return tblGames;
        }

        // PUT: api/TblGames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblGames(int id, TblGames tblGames)
        {
            if (id != tblGames.id)
            {
                return BadRequest();
            }

            _context.Entry(tblGames).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblGamesExists(id))
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

        // POST: api/TblGames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblGames>> PostTblGames(TblGames tblGames)
        {
          if (_context.TblGames == null)
          {
              return Problem("Entity set 'ServerContext.TblGames'  is null.");
          }
            _context.TblGames.Add(tblGames);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblGames", new { id = tblGames.id }, tblGames);
        }

        // DELETE: api/TblGames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblGames(int id)
        {
            if (_context.TblGames == null)
            {
                return NotFound();
            }
            var tblGames = await _context.TblGames.FindAsync(id);
            if (tblGames == null)
            {
                return NotFound();
            }

            _context.TblGames.Remove(tblGames);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblGamesExists(int id)
        {
            return (_context.TblGames?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
