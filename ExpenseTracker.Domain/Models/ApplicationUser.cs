using System.ComponentModel.DataAnnotations.Schema;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Identity;

namespace ExpenseTracker.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName ="nvarchar(100)")]
    public string FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }
    
    public int? TransactionId { get; set; }
    public Transaction? Transaction { get; set; }

}

