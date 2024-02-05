using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpravljanjeTransakcijama.Infastruktura.Migrations
{
    /// <inheritdoc />
    public partial class Dodajemopogled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var command = @"create view PrikaziSveTransakcije as
                            select kolicina, opis, datum, AppUserID, Transakcija.KategorijaID, Naziv, Ikonica
                            from Transakcija, Kategorija
                            where Transakcija.KategorijaID = Kategorija.KategorijaID";
            migrationBuilder.Sql(command);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var command = @"DROP VIEW PrikaziSveTransakcije;";
            migrationBuilder.Sql(command);
        }
    }
}
