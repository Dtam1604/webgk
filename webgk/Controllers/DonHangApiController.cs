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
    public class DonHangApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DonHangApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DonHangApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonHang>>> GetDonHangs()
        {
            return await _context.DonHangs
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        // GET: api/DonHangApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonHang>> GetDonHang(int id)
        {
            var donHang = await _context.DonHangs
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(dh => dh.MaDon == id);

            if (donHang == null)
            {
                return NotFound();
            }

            return donHang;
        }

        // PUT: api/DonHangApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonHang(int id, DonHang donHang)
        {
            if (id != donHang.MaDon)
            {
                return BadRequest();
            }

            _context.Entry(donHang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonHangExists(id))
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

        // POST: api/DonHangApi
        [HttpPost]
        public async Task<ActionResult<DonHang>> PostDonHang(DonHang donHang)
        {
            try
            {
                _context.DonHangs.Add(donHang);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetDonHang), new { id = donHang.MaDon }, donHang);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Đã xảy ra lỗi khi lưu đơn hàng.");
            }
        }

        // DELETE: api/DonHangApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonHang(int id)
        {
            var donHang = await _context.DonHangs.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }

            _context.DonHangs.Remove(donHang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonHangExists(int id)
        {
            return _context.DonHangs.Any(e => e.MaDon == id);
        }
    }
}
