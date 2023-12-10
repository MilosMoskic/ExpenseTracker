using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ExpenseTracker.Interfejsi;

namespace ExpenseTracker.Controllers
{
    [Authorize]
    public class PocetnaController : Controller
    {
        private readonly ITransakcijaServis _transakcijaServis;

        public PocetnaController(ITransakcijaServis transakcijaServis)
        {
            _transakcijaServis = transakcijaServis;
        }
        public async Task<ActionResult> Index()
        {
            var korisnikId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //Total Income
            int UkupniPrihod = _transakcijaServis.IzracunajTotalniPrihod(korisnikId);
            ViewBag.UkupniPrihod = UkupniPrihod.ToString("C0");

            //Total Expense
            int UkupniTrosak = _transakcijaServis.IzracunajTotalniTrosak(korisnikId);
            ViewBag.TotalExpense = UkupniTrosak.ToString("C0");

            //Balance
            int Stanje = UkupniPrihod - UkupniTrosak;
            ViewBag.Stanje = Stanje.ToString("C0");

            return View();
        }
    }
}
