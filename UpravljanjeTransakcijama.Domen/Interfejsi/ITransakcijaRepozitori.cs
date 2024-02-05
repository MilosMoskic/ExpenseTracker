using ExpenseTracker.Modeli;
using UpravljanjeTransakcijama.Domen.Modeli;

namespace ExpenseTracker.Interfejsi
{
    public interface ITransakcijaRepozitori
    {
        Transakcija PronadjiTransakciju(int id);
        ICollection<Transakcija> ListujSveTransakcije();
        ICollection<TransakcijaPogled> ListujSveTransakcijePogled();
        bool TransakcijaPostoji(int id);
        bool NapraviTransakciju(Transakcija transakcija);
        bool NapraviTransakciju(int kategorijaID, int kolicina, string opis, DateTime datum, string appUserID);
        bool IzmeniTransakcije(Transakcija transakcija);
        bool ObrisiTransakciju(Transakcija transakcija);
        List<Transakcija> TransaAkcijeZaPocetnuStranicu(string korisnikId);
        int IzracunajTotalniPrihod(string korisnikId);
        int IzracunajTotalniTrosak(string korisnikId);
        ICollection<Transakcija> SearchovanaTransakcija(int searchovanID);
        bool Sacuvaj();
    }
}
