using ExpenseTracker.Kontekst;
using ExpenseTracker.Interfejsi;
using ExpenseTracker.Modeli;
using ExpenseTracker.Areas.Identity.Data;

namespace ExpenseTracker.Repozitorijumi
{
    public class KategorijaRepozitori : IKategorijaRepozitori
    {
        private readonly KlasaKontekst _context;

        public KategorijaRepozitori(KlasaKontekst context)
        {
            _context = context;
        }

        public bool KategorijaPostoji(int id)
        {
            return _context.Kategorija.Any(c => c.KategorijaId== id);
        }

        public bool NapraviKategoriju(Kategorija kategorija)
        {
            _context.Add(kategorija);
            return Sacuvaj();
        }

        public bool ObrisiKategoriju(Kategorija kategorija)
        {
            _context.Remove(kategorija);
            return Sacuvaj();
        }

        public Kategorija PronadjiKategoriju(int id)
        {
            return _context.Kategorija.Where(c => c.KategorijaId == id).FirstOrDefault();
        }

        public ICollection<Kategorija> ListujSveKategorije()
        {
            return _context.Kategorija.OrderBy(c => c.KategorijaId).ToList();
        }

        public ICollection<Kategorija> FiltrirajPoPrihodu()
        {
            return _context.Kategorija.Where(c => c.Tip == "Prihod").ToList();
        }

        public ICollection<Kategorija> FiltrirajPoTrosku()
        {
            return _context.Kategorija.Where(c => c.Tip == "Trosak").ToList();
        }
        public bool Sacuvaj()
        {
            var sacuvano = _context.SaveChanges();
            return sacuvano > 0 ? true : false;
        }

        public bool IzmeniKategoriju(Kategorija kategorija)
        {
            _context.Update(kategorija);
            return Sacuvaj();
        }
    }
}
