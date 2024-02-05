using ExpenseTracker.Modeli;
using UpravljanjeTransakcijama.Domen.Modeli;

namespace ExpenseTracker.Interfejsi
{
    public interface ITransakcijaServis
    {
        Transakcija PronadjiTransakciju(int id);
        ICollection<Transakcija> ListujSveTransakcije();
        ICollection<TransakcijaPogled> ListujSveTransakcijePogled();
        bool NapraviTransakciju(Transakcija transakcija);
        bool NapraviTransakciju(int kategorijaID, int kolicina, string opis, DateTime datum, string appUserID);
        bool ObrisiTransakciju(Transakcija transakcija);
        bool IzmeniTransakciju(Transakcija transakcija);
        bool TransakcijaPostoji(int id);
        int IzracunajTotalniPrihod(string korisnikId);
        int IzracunajTotalniTrosak(string korisnikId);
        ICollection<Transakcija> SearchovanaTransakcija(int searchovanID);
        List<Transakcija> TransaAkcijeZaPocetnuStranicu(string korisnikId);
    }
}
