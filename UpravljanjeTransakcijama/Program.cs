using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using ExpenseTracker.Services;
using ExpenseTracker.Repozitorijumi;
using ExpenseTracker.Interfejsi;
using ExpenseTracker.Kontekst;
using ExpenseTracker.Servisi;
using UpravljanjeTransakcijama.Infastruktura.PoslovnaPravila;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IKategorijaRepozitori, KategorijaRepozitori>();
builder.Services.AddScoped<IKategorijaServis, KategorijaServis>();
builder.Services.AddScoped<ITransakcijaRepozitori, TransakcijaRepozitori>();
builder.Services.AddScoped<ITransakcijaServis, TransakcijaServis>();
builder.Services.AddScoped<IPoslovnaPravila, PoslovnaPravila>();

builder.Services.AddDbContext<KlasaKontekst>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<KlasaKontekst>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pocetna}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
