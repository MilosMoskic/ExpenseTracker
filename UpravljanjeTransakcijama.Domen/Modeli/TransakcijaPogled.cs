namespace UpravljanjeTransakcijama.Domen.Modeli
{
    public class TransakcijaPogled
    {
        public int Kolicina { get; set; }
        public string Opis { get; set; }
        public DateTime Datum { get; set; }
        public string AppUserID { get; set; }
        public int KategorijaID { get; set; }
        public string KategorijaIkonica { get; set; }
    }
}
