using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using siekskul.Data;
using siekskul.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace siekskul.Controllers
{
    public class EkstrakurikulerController : Controller
    {
        private readonly AppDbContext _context;

        public EkstrakurikulerController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ekstrakurikuler = await _context.Ekstrakurikuler
                .Include(e => e.Guru)
                .ThenInclude(g => g.User)
                .ToListAsync();
            return View(ekstrakurikuler);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ekstrakurikuler = await _context.Ekstrakurikuler
                .Include(e => e.Guru)
                .ThenInclude(g => g.User)
                .Include(e => e.Jadwal)
                .FirstOrDefaultAsync(m => m.EkstrakurikulerId == id);

            if (ekstrakurikuler == null)
            {
                return NotFound();
            }

            return View(ekstrakurikuler);
        }
        [Authorize(Roles = "Siswa")]
        public async Task<IActionResult> ListForSiswa()
        {
            var ekstrakurikuler = await _context.Ekstrakurikuler
                .Include(e => e.Guru)
                .ThenInclude(g => g.User)
                .ToListAsync();
            return View(ekstrakurikuler);
        }

        [Authorize(Roles = "Guru")]
        public async Task<IActionResult> PendaftaranList()
        {
            var pendaftaran = await _context.PendaftaranEkstrakurikuler
                .Include(p => p.Siswa)
                .ThenInclude(s => s.User)
                .Include(p => p.Ekstrakurikuler)
                .ToListAsync();
            return View(pendaftaran);
        }

        [Authorize(Roles = "Siswa")]
        public async Task<IActionResult> Daftar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ekstrakurikuler = await _context.Ekstrakurikuler
                .Include(e => e.Guru)
                .FirstOrDefaultAsync(m => m.EkstrakurikulerId == id);

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

            return RedirectToAction(nameof(Index));
        }
    }
}