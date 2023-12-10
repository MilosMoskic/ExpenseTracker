using ExpenseTracker.Interfejsi;
using ExpenseTracker.Modeli;

namespace ExpenseTracker.Servisi
{
    public class KategorijaServis : IKategorijaServis
    {
        private readonly IKategorijaRepozitori _kategorijaRepozitori;
        public KategorijaServis(IKategorijaRepozitori kategorijaRepozitori)
        {
            _kategorijaRepozitori = kategorijaRepozitori;
        }

        public ICollection<Kategorija> ListujSveKategorije()
        {
            return _kategorijaRepozitori.ListujSveKategorije();
        }
        public Kategorija PronadjiKategoriju(int id)
        {
            return _kategorijaRepozitori.PronadjiKategoriju(id);
        }
        public bool NapraviKategoriju(Kategorija kategorija)
        {
            return _kategorijaRepozitori.NapraviKategoriju(kategorija);
        }
        public ICollection<Kategorija> FiltrirajPoPrihodu()
        {
            return _kategorijaRepozitori.FiltrirajPoPrihodu();
        }

        public ICollection<Kategorija> FiltrirajPoTrosku()
        {
            return _kategorijaRepozitori.FiltrirajPoTrosku();
        }
        public bool ObrisiKategoriju(int id)
        {
            var kategorijaZaBrisanje = _kategorijaRepozitori.PronadjiKategoriju(id);
            return _kategorijaRepozitori.ObrisiKategoriju(kategorijaZaBrisanje);
        }
        public bool IzmeniKategoriju(Kategorija kategorija)
        {
            return _kategorijaRepozitori.IzmeniKategoriju(kategorija);
        }
        public bool KategorijaPostoji(int id)
        {
            return _kategorijaRepozitori.KategorijaPostoji(id);
        }
    }
}
