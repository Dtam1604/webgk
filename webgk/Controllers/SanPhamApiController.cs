using Microsoft.AspNetCore.Mvc;
using webgk.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webgk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SanPhamApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SanPhamApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<sanpham>>> GetALL()
        {
            var sanPhams = await _context.SanPhams.ToListAsync();
            return Ok(sanPhams);
        }

        // GET api/SanPhamApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<sanpham>> GetSanPham(int id)
        {
            var sanpham = await _context.SanPhams.FindAsync(id);

            if (sanpham == null)
            {
                return NotFound();
            }

            return Ok(sanpham);
        }

        // POST api/SanPhamApi
        [HttpPost]
        public async Task<ActionResult<sanpham>> PostSanPham(sanpham sanpham)
        {
            // Đảm bảo không gán giá trị cho trường ID
            sanpham.ID = 0;

            _context.SanPhams.Add(sanpham);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSanPham), new { id = sanpham.ID }, sanpham);
        }


        // PUT api/SanPhamApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanPham(int id, sanpham sanpham)
        {
            if (id != sanpham.ID)
            {
                return BadRequest();
            }

            _context.Entry(sanpham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamExists(id))
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

        // DELETE api/SanPhamApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanPham(int id)
        {
            var sanpham = await _context.SanPhams.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }

            _context.SanPhams.Remove(sanpham);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.ID == id);
        }
    }
}
