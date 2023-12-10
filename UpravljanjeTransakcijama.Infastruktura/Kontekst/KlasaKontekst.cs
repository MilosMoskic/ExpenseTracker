using ExpenseTracker.Areas.Identity.Data;
using ExpenseTracker.Modeli;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Kontekst;

public class KlasaKontekst : IdentityDbContext<ApplicationUser>
{
    public KlasaKontekst(DbContextOptions<KlasaKontekst> options)
        : base(options)
    {
    }

    public DbSet<Transakcija> Transakcija { get; set; }
    public DbSet<Kategorija> Kategorija { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
