using ExpenseTracker.Areas.Identity.Data;
using ExpenseTracker.Modeli;

namespace ExpenseTracker.Interfejsi
{
    public interface IKategorijaRepozitori
    {
        Kategorija PronadjiKategoriju(int id);
        ICollection<Kategorija> ListujSveKategorije();
        ICollection<Kategorija> FiltrirajPoPrihodu();
        ICollection<Kategorija> FiltrirajPoTrosku();
        bool KategorijaPostoji(int id);
        bool NapraviKategoriju(Kategorija kategorija);
        bool IzmeniKategoriju(Kategorija kategorija);
        bool ObrisiKategoriju(Kategorija kategorija);
        bool Sacuvaj();
    }
}
