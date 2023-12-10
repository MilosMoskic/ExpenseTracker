using ExpenseTracker.Interfejsi;
using ExpenseTracker.Modeli;

namespace ExpenseTracker.Services
{
    public class TransakcijaServis : ITransakcijaServis
    {
        private readonly ITransakcijaRepozitori _transakcijaRepozitori;
        public TransakcijaServis(ITransakcijaRepozitori transakcijaRepozitori)
        {
            _transakcijaRepozitori = transakcijaRepozitori;
        }

        public Transakcija PronadjiTransakciju(int id)
        {
            return _transakcijaRepozitori.PronadjiTransakciju(id);
        }
        public ICollection<Transakcija> ListujSveTransakcije()
        {
            return _transakcijaRepozitori.ListujSveTransakcije();
        }
        public bool NapraviTransakciju(Transakcija transaction)
        {
            return _transakcijaRepozitori.NapraviTransakciju(transaction);
        }

        public bool ObrisiTransakciju(Transakcija transakcija)
        {
            return _transakcijaRepozitori.ObrisiTransakciju(transakcija);
        }
        public bool IzmeniTransakciju(Transakcija transakcija)
        {
            return _transakcijaRepozitori.IzmeniTransakcije(transakcija);
        }
        public bool TransakcijaPostoji(int id)
        {
            return _transakcijaRepozitori.TransakcijaPostoji(id);
        }
        public int IzracunajTotalniPrihod(string korisnikId)
        {
            return _transakcijaRepozitori.IzracunajTotalniPrihod(korisnikId);
        }
        public int IzracunajTotalniTrosak(string korisnikId)
        {
            return _transakcijaRepozitori.IzracunajTotalniTrosak(korisnikId);
        }
        public List<Transakcija> TransaAkcijeZaPocetnuStranicu(string korisnikId)
        {
            return _transakcijaRepozitori.TransaAkcijeZaPocetnuStranicu(korisnikId);
        }
    }
}
