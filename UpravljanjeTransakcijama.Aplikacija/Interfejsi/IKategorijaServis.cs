using ExpenseTracker.Areas.Identity.Data;
using ExpenseTracker.Modeli;

namespace ExpenseTracker.Interfejsi
{
    public interface IKategorijaServis
    {
        ICollection<Kategorija> ListujSveKategorije();
        ICollection<Kategorija> FiltrirajPoPrihodu();
        ICollection<Kategorija> FiltrirajPoTrosku();
        Kategorija PronadjiKategoriju(int id);
        bool NapraviKategoriju(Kategorija kategorija);
        bool ObrisiKategoriju(int id);
        bool IzmeniKategoriju(Kategorija kateogrija);
        bool KategorijaPostoji(int id);
    }
}