using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Modeli;
using Microsoft.AspNetCore.Authorization;
using ExpenseTracker.Interfejsi;
using ExpenseTracker.Areas.Identity.Data;

namespace ExpenseTracker.Controllers
{
    [Authorize]
    public class KategorijaController : Controller
    {
        private readonly IKategorijaServis _kategorijaServis;

        public KategorijaController(IKategorijaServis kategorijaServis)
        {
            _kategorijaServis = kategorijaServis;
        }

        public IActionResult Index()
        {
              return View(_kategorijaServis.ListujSveKategorije());
        }

        public IActionResult FiltrirajPoPrihodu()
        {
            return View(_kategorijaServis.FiltrirajPoPrihodu());
        }

        public IActionResult FiltrirajPoTrosku()
        {
            return View(_kategorijaServis.FiltrirajPoTrosku());
        }

        public IActionResult DodajIliIzmeni(int id = 0)
        {
            if (id == 0)
                return View(new Kategorija());
            else
                return View(_kategorijaServis.PronadjiKategoriju(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DodajIliIzmeni([Bind("KategorijaId,Naziv,Ikonica,Tip")] Kategorija kategorija)
        {
            if (ModelState.IsValid)
            {
                if (kategorija.KategorijaId == 0)
                    _kategorijaServis.NapraviKategoriju(kategorija);
                else
                    _kategorijaServis.IzmeniKategoriju(kategorija);
                return RedirectToAction(nameof(Index));
            }
            return View(kategorija);
        }

        [HttpPost, ActionName("Obrisi")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BrisanjePotvrdjeno(int id)
        {
            if (_kategorijaServis.KategorijaPostoji(id) == false)
            {
                return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
            }

            if (_kategorijaServis.KategorijaPostoji(id) != false)
            {
                _kategorijaServis.ObrisiKategoriju(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
