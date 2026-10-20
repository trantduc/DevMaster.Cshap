using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab11.API.QLBanHang.Models.DBModel;

namespace lesson11.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonkhosController : ControllerBase
    {
        private readonly QlbanHangContext _context;

        public TonkhosController(QlbanHangContext context)
        {
            _context = context;
        }

        // GET: api/Tonkhos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tonkho>>> GetTonkhos()
        {
            return await _context.Tonkhos.ToListAsync();
        }

        // GET: api/Tonkhos/202610/VT01
        [HttpGet("{namthang}/{mavtu}")]
        public async Task<ActionResult<Tonkho>> GetTonkho(string namthang, string mavtu)
        {
            var tonkho = await _context.Tonkhos.FindAsync(namthang, mavtu);

            if (tonkho == null)
            {
                return NotFound();
            }

            return tonkho;
        }

        // POST: api/Tonkhos
        [HttpPost]
        public async Task<ActionResult<Tonkho>> PostTonkho(Tonkho tonkho)
        {
            _context.Tonkhos.Add(tonkho);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (_context.Tonkhos.Any(e => e.NamThang == tonkho.NamThang && e.Mavtu == tonkho.Mavtu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetTonkho), new { namthang = tonkho.NamThang, mavtu = tonkho.Mavtu }, tonkho);
        }

        // DELETE: api/Tonkhos/202610/VT01
        [HttpDelete("{namthang}/{mavtu}")]
        public async Task<IActionResult> DeleteTonkho(string namthang, string mavtu)
        {
            var tonkho = await _context.Tonkhos.FindAsync(namthang, mavtu);
            if (tonkho == null)
            {
                return NotFound();
            }

            _context.Tonkhos.Remove(tonkho);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}