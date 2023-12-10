using ExpenseTracker.Interfejsi;
using ExpenseTracker.Kontekst;
using ExpenseTracker.Modeli;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Repozitorijumi
{
    public class TransakcijaRepozitori : ITransakcijaRepozitori
    {
        private readonly KlasaKontekst _context;

        public TransakcijaRepozitori(KlasaKontekst context)
        {
            _context = context;
        }

        public int IzracunajTotalniPrihod(string korisnikId)
        {
            List<Transakcija> SelektovaneTransakcije = TransaAkcijeZaPocetnuStranicu(korisnikId);
            return SelektovaneTransakcije
                .Where(i => i.Kategorija.Tip == "Prihod")
                .Sum(j => j.Kolicina);
        }

        public int IzracunajTotalniTrosak(string korisnikId)
        {
            List<Transakcija> SelektovaneTransakcije = TransaAkcijeZaPocetnuStranicu(korisnikId);
            return SelektovaneTransakcije
                .Where(i => i.Kategorija.Tip == "Trosak")
                .Sum(j => j.Kolicina);
        }

        public bool NapraviTransakciju(Transakcija transakcija)
        {
            _context.Add(transakcija);
            return Sacuvaj();
        }

        public bool ObrisiTransakciju(Transakcija transakcija)
        {
            _context.Remove(transakcija);
            return Sacuvaj();
        }

        public Transakcija PronadjiTransakciju(int id)
        {
            return _context.Transakcija.Where(t => t.TransakcijaId == id).Include(t => t.Kategorija).FirstOrDefault();
        }

        public ICollection<Transakcija> ListujSveTransakcije()
        {
            return _context.Transakcija.Include(t => t.Kategorija).ToList();
        }

        public bool Sacuvaj()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TransakcijaPostoji(int id)
        {
            return _context.Transakcija.Any(t => t.TransakcijaId == id);
        }

        public List<Transakcija> TransaAkcijeZaPocetnuStranicu(string korisnikId)
        {
            DateTime PocetiniDatum = DateTime.Today.AddDays(-6);
            DateTime KrajnjiDatum = DateTime.Today;
            return _context.Transakcija.Include(x => x.Kategorija)
                .Where(y => y.Datum >= PocetiniDatum && y.Datum <= KrajnjiDatum && y.AppUserID == korisnikId)
                .ToList();
        }
        public bool IzmeniTransakcije(Transakcija transakcija)
        {
            _context.Update(transakcija);
            return Sacuvaj();
        }
    }
}
