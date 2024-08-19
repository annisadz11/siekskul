using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using siekskul.Data;
using siekskul.Models;

namespace siekskul.Controllers
{
    [Authorize]
    public class PendaftaranController : Controller
    {
        private readonly AppDbContext _context;

        public PendaftaranController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Siswa")]
        public async Task<IActionResult> Status()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var pendaftaran = await _context.PendaftaranEkstrakurikuler
                .Include(p => p.Ekstrakurikuler)
                .Where(p => p.Siswa.UserId.ToString() == userId)
                .ToListAsync();

            return View(pendaftaran);
        }

        [Authorize(Roles = "Siswa")]
        public async Task<IActionResult> Daftar(int id)
        {
            var ekstrakurikuler = await _context.Ekstrakurikuler
                .FirstOrDefaultAsync(e => e.EkstrakurikulerId == id);

            if (ekstrakurikuler == null)
            {
                return NotFound();
            }

            return View(ekstrakurikuler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Siswa")]
        public async Task<IActionResult> DaftarConfirm(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var siswa = await _context.Siswas.FirstOrDefaultAsync(s => s.UserId.ToString() == userId);

            if (siswa == null)
            {
                return NotFound();
            }

            var pendaftaran = new PendaftaranEkstrakurikuler
            {
                SiswaId = siswa.SiswaId,
                EkstrakurikulerId = id,
                TanggalPendaftaran = DateTime.Now,
                Status = StatusPendaftaran.Menunggu
            };

            _context.PendaftaranEkstrakurikuler.Add(pendaftaran);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Status));
        }
    }
}