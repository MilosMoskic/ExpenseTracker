using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Modeli
{
    public class Transakcija
    {
        [Key]
        public int TransakcijaId { get; set; }
        public int KategorijaId { get; set; }
        public Kategorija? Kategorija { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public int Kolicina { get; set; }
        [Column(TypeName = "nvarchar(75)")]
        public string? Opis { get; set; } = "Bez opisa";
        public DateTime Datum { get; set; } = DateTime.Now;
        [ForeignKey("ApplicationUser")]
        public string AppUserID { get; set; }
        [NotMapped]
        public string? KolicinaZaFormatiranje 
        {
            get
            {
                return ((Kategorija == null || Kategorija.Tip == "Trosak") ? "- " : "+ ") + Kolicina.ToString("C0");
            }
        }
    }   
}
