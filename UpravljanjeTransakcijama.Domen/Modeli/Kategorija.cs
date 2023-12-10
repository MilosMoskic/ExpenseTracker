using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Modeli
{
    public class Kategorija
    {
        [Key]
        public int KategorijaId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Naziv { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Ikonica { get; set; } = "";

        [Column(TypeName = "nvarchar(10)")]
        public string Tip { get; set; } = "Trosak";

        [NotMapped]
        public string? TipSaIkonicom {
            get
            {
                return this.Ikonica + " " + this.Naziv;     
            }
        }
    }
}
