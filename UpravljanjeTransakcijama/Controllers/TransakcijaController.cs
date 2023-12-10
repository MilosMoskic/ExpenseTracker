﻿using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Modeli;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ExpenseTracker.Interfejsi;

namespace ExpenseTracker.Controllers
{
    [Authorize]
    public class TransakcijaController : Controller
    {
        private readonly ITransakcijaServis _transakcijaServis;
        private readonly IKategorijaServis _kategorijaServis;

        public TransakcijaController(ITransakcijaServis transakcijaServis, IKategorijaServis kategorijaServis)
        {
            _transakcijaServis = transakcijaServis;
            _kategorijaServis = kategorijaServis;
        }

        public IActionResult Index()
        {
            var naslovSaKategorijom = _transakcijaServis.ListujSveTransakcije();
            return View(naslovSaKategorijom);
        }

        public IActionResult DodajIliIzmeni(int id=0)
        {
            NapuniKategorije();
            if (id == 0)
                return View(new Transakcija());
            else
                return View(_transakcijaServis.PronadjiTransakciju(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DodajIliIzmeni([Bind("TransakcijaId,KategorijaId,Kolicina,Opis,Datum,AppUserID")] Transakcija transakcija)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (transakcija.TransakcijaId == 0) 
            {
                transakcija.AppUserID = userId;
                _transakcijaServis.NapraviTransakciju(transakcija);
            }
            else
            {
                transakcija.AppUserID = userId;
                _transakcijaServis.IzmeniTransakciju(transakcija);
            }

            return RedirectToAction(nameof(Index));

        }

        [HttpPost, ActionName("Obrisi")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BrisanjePotvrdjeno(int id)
        {
            if (_transakcijaServis.TransakcijaPostoji(id) == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Transactions'  is null.");
            }
            var transakcija = _transakcijaServis.PronadjiTransakciju(id);
            if (_transakcijaServis.TransakcijaPostoji(id) != null)
            {
                _transakcijaServis.ObrisiTransakciju(transakcija);
            }
            
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Ispis(int id)
        {
            return View(_transakcijaServis.PronadjiTransakciju(id));
        }

        [NonAction]
        public void NapuniKategorije()
        {
            var KolekcijaKategorija = _kategorijaServis.ListujSveKategorije();
            Kategorija DifalutnaKategorija = new Kategorija() { KategorijaId = 0, Naziv = "Izaberite Kategoriju" };
            KolekcijaKategorija.Add(DifalutnaKategorija);
            ViewBag.Kategorije = KolekcijaKategorija;
        }
    }
}
