using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webgk.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webgk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KhachApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/KhachApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Khach>>> GetKhachs()
        {
            return await _context.KhachHangs.AsNoTracking().ToListAsync();
        }

        // GET: api/KhachApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Khach>> GetKhach(string id)
        {
            var khach = await _context.KhachHangs.FindAsync(id);

            if (khach == null)
            {
                return NotFound();
            }

            return Ok (khach);
        }

        // PUT: api/KhachApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhach(string id, Khach khach)
        {
            if (id != khach.MaKhach)
            {
                return BadRequest();
            }

            _context.Entry(khach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhachExists(id))
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

        // POST: api/KhachApi
        [HttpPost]
        public async Task<ActionResult<Khach>> PostKhach(Khach khach)
        {
            _context.KhachHangs.Add(khach);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKhach), new { id = khach.MaKhach }, khach);
        }

        // DELETE: api/KhachApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhach(string id)
        {
            var khach = await _context.KhachHangs.FindAsync(id);
            if (khach == null)
            {
                return NotFound();
            }

            _context.KhachHangs.Remove(khach);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhachExists(string id)
        {
            return _context.KhachHangs.Any(e => e.MaKhach == id);
        }
    }
}
