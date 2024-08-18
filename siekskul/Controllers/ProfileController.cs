using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using siekskul.Data;
using siekskul.Models;
using siekskul.ViewModels;
using System.Security.Claims;

namespace siekskul.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(AppDbContext context, ILogger<ProfileController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = int.Parse(User.FindFirstValue("UserId"));
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new ProfileViewModel
            {
                UserId = user.UserId,
                Username = user.Username,
                FullName = user.FullName,
                Role = user.Role
            };

            if (user.Role == UserRole.Siswa)
            {
                var siswa = await _context.Siswas.FirstOrDefaultAsync(s => s.UserId == userId);
                if (siswa != null)
                {
                    viewModel.SiswaId = siswa.SiswaId;
                    viewModel.NIS = siswa.NIS;
                    viewModel.Kelas = siswa.Kelas;
                    viewModel.JenisKelamin = siswa.JenisKelamin;
                    viewModel.Agama = siswa.Agama;
                    viewModel.TempatLahir = siswa.TempatLahir;
                    viewModel.TanggalLahir = siswa.TanggalLahir;
                    viewModel.Alamat = siswa.Alamat;
                    viewModel.NamaAyah = siswa.NamaAyah;
                    viewModel.NamaIbu = siswa.NamaIbu;
                }
            }
            else if (user.Role == UserRole.Guru)
            {
                var guru = await _context.Gurus.FirstOrDefaultAsync(g => g.UserId == userId);
                if (guru != null)
                {
                    viewModel.GuruId = guru.GuruId;
                    viewModel.NIP = guru.NIP;
                    viewModel.JenisKelamin = guru.JenisKelamin;
                    viewModel.Agama = guru.Agama;
                    viewModel.TempatLahir = guru.TempatLahir;
                    viewModel.TanggalLahir = guru.TanggalLahir;
                    viewModel.BidangEkstrakurikuler = guru.BidangEkstrakurikuler;
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProfileViewModel model)
        {
            _logger.LogInformation("POST Update method called.");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState is invalid.");
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        _logger.LogError($"ModelState Error: {state.Key}: {error.ErrorMessage}");
                    }
                }
                return View("Index", model);
            }

            var user = await _context.Users.FindAsync(model.UserId);
            if (user == null)
            {
                _logger.LogWarning("User not found.");
                return NotFound();
            }

            user.FullName = model.FullName;

            if (user.Role == UserRole.Siswa)
            {
                var siswa = await _context.Siswas.FirstOrDefaultAsync(s => s.UserId == model.UserId);
                if (siswa == null)
                {
                    siswa = new Siswa { UserId = model.UserId };
                    _context.Siswas.Add(siswa);
                    await _context.SaveChangesAsync();
                }

                siswa.NIS = model.NIS;
                siswa.Kelas = model.Kelas;
                siswa.JenisKelamin = model.JenisKelamin;
                siswa.Agama = model.Agama;
                siswa.TempatLahir = model.TempatLahir;
                siswa.TanggalLahir = model.TanggalLahir;
                siswa.Alamat = model.Alamat;
                siswa.NamaAyah = model.NamaAyah;
                siswa.NamaIbu = model.NamaIbu;

                _context.Siswas.Update(siswa);
            }
            else if (user.Role == UserRole.Guru)
            {
                var guru = await _context.Gurus.FirstOrDefaultAsync(g => g.UserId == model.UserId);
                if (guru == null)
                {
                    guru = new Guru { UserId = model.UserId };
                    _context.Gurus.Add(guru);
                    await _context.SaveChangesAsync();
                }

                guru.NIP = model.NIP;
                guru.JenisKelamin = model.JenisKelamin;
                guru.Agama = model.Agama;
                guru.TempatLahir = model.TempatLahir;
                guru.TanggalLahir = model.TanggalLahir;
                guru.BidangEkstrakurikuler = model.BidangEkstrakurikuler;

                _context.Gurus.Update(guru);
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Profile updated successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}