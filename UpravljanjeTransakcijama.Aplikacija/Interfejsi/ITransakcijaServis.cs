using ExpenseTracker.Modeli;

namespace ExpenseTracker.Interfejsi
{
    public interface ITransakcijaServis
    {
        Transakcija PronadjiTransakciju(int id);
        ICollection<Transakcija> ListujSveTransakcije();
        bool NapraviTransakciju(Transakcija transakcija);
        bool ObrisiTransakciju(Transakcija transakcija);
        bool IzmeniTransakciju(Transakcija transakcija);
        bool TransakcijaPostoji(int id);
        int IzracunajTotalniPrihod(string korisnikId);
        int IzracunajTotalniTrosak(string korisnikId);
        List<Transakcija> TransaAkcijeZaPocetnuStranicu(string korisnikId);
    }
}
