using ExpenseTracker.Modeli;

namespace ExpenseTracker.Interfejsi
{
    public interface ITransakcijaRepozitori
    {
        Transakcija PronadjiTransakciju(int id);
        ICollection<Transakcija> ListujSveTransakcije();
        bool TransakcijaPostoji(int id);
        bool NapraviTransakciju(Transakcija transakcija);
        bool IzmeniTransakcije(Transakcija transakcija);
        bool ObrisiTransakciju(Transakcija transakcija);
        List<Transakcija> TransaAkcijeZaPocetnuStranicu(string korisnikId);
        int IzracunajTotalniPrihod(string korisnikId);
        int IzracunajTotalniTrosak(string korisnikId);
        bool Sacuvaj();
    }
}
