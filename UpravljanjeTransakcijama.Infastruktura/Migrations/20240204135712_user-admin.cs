using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpravljanjeTransakcijama.Infastruktura.Migrations
{
    /// <inheritdoc />
    public partial class useradmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tip",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tip",
                table: "AspNetUsers");
        }
    }
}
