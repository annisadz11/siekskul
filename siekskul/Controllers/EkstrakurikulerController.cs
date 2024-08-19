using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using siekskul.Data;
using siekskul.Models;
using System.Linq;
using System.Threading.Tasks;

namespace siekskul.Controllers
{
    [Authorize(Roles = "Guru")]
    public class EkstrakurikulerController : Controller
    {
        private readonly AppDbContext _context;

        public EkstrakurikulerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Ekstrakurikuler
        public async Task<IActionResult> Index()
        {
            var ekstrakurikuler = await _context.Ekstrakurikuler
                .Include(e => e.Guru)
                .ThenInclude(g => g.User)
                .ToListAsync();
            return View(ekstrakurikuler);
        }

        // GET: Ekstrakurikuler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ekstrakurikuler = await _context.Ekstrakurikuler
                .Include(e => e.Guru)
                .ThenInclude(g => g.User)
                .FirstOrDefaultAsync(m => m.EkstrakurikulerId == id);

            if (ekstrakurikuler == null)
            {
                return NotFound();
            }

            return View(ekstrakurikuler);
        }

        // GET: Ekstrakurikuler/Create
        public IActionResult Create()
        {
            ViewBag.GuruList = new SelectList(_context.Gurus.Include(g => g.User), "GuruId", "User.FullName");
            return View();
        }

        // POST: Ekstrakurikuler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nama,Deskripsi,GuruId")] Ekstrakurikuler ekstrakurikuler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ekstrakurikuler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.GuruList = new SelectList(_context.Gurus.Include(g => g.User), "GuruId", "User.FullName", ekstrakurikuler.GuruId);
            return View(ekstrakurikuler);
        }

        // GET: Ekstrakurikuler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ekstrakurikuler = await _context.Ekstrakurikuler.FindAsync(id);
            if (ekstrakurikuler == null)
            {
                return NotFound();
            }
            ViewBag.GuruList = new SelectList(_context.Gurus.Include(g => g.User), "GuruId", "User.FullName", ekstrakurikuler.GuruId);
            return View(ekstrakurikuler);
        }

        // POST: Ekstrakurikuler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EkstrakurikulerId,Nama,Deskripsi,GuruId")] Ekstrakurikuler ekstrakurikuler)
        {
            if (id != ekstrakurikuler.EkstrakurikulerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ekstrakurikuler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EkstrakurikulerExists(ekstrakurikuler.EkstrakurikulerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.GuruList = new SelectList(_context.Gurus.Include(g => g.User), "GuruId", "User.FullName", ekstrakurikuler.GuruId);
            return View(ekstrakurikuler);
        }

        // GET: Ekstrakurikuler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ekstrakurikuler = await _context.Ekstrakurikuler
                .Include(e => e.Guru)
                .ThenInclude(g => g.User)
                .FirstOrDefaultAsync(m => m.EkstrakurikulerId == id);
            if (ekstrakurikuler == null)
            {
                return NotFound();
            }

            return View(ekstrakurikuler);
        }

        // POST: Ekstrakurikuler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ekstrakurikuler = await _context.Ekstrakurikuler.FindAsync(id);
            _context.Ekstrakurikuler.Remove(ekstrakurikuler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Ekstrakurikuler/PendaftaranList
        public async Task<IActionResult> PendaftaranList()
        {
            var pendaftaran = await _context.PendaftaranEkstrakurikuler
                .Include(p => p.Siswa)
                .ThenInclude(s => s.User)
                .Include(p => p.Ekstrakurikuler)
                .ToListAsync();
            return View(pendaftaran);
        }

        // POST: Ekstrakurikuler/UpdateStatus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var pendaftaran = await _context.PendaftaranEkstrakurikuler.FindAsync(id);
            if (pendaftaran == null)
            {
                return NotFound();
            }

            pendaftaran.Status = (StatusPendaftaran)Enum.Parse(typeof(StatusPendaftaran), status);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(PendaftaranList));
        }

        private bool EkstrakurikulerExists(int id)
        {
            return _context.Ekstrakurikuler.Any(e => e.EkstrakurikulerId == id);
        }
    }
}