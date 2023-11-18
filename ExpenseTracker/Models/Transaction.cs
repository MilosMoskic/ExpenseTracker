using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Range(1,int.MaxValue, ErrorMessage ="Please select a category.")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public int Amount { get; set; }
        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; } = "None";
        public DateTime Date { get; set; } = DateTime.Now;
        [ForeignKey("ApplicationUser")]
        public string AppUserID { get; set; }

        [NotMapped]
        public string? FormattingAmount 
        {
            get
            {
                return ((Category == null || Category.Type == "Expense") ? "- " : "+ ") + Amount.ToString("C0");
            }
        }
    }   
}
