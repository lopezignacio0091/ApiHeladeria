using Microsoft.EntityFrameworkCore.Migrations;

namespace Positano.Persistence.Migrations
{
    public partial class updateTableTasteStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tastes",
                newName: "TypeTaste");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeTaste",
                table: "Tastes",
                newName: "Status");
        }
    }
}
