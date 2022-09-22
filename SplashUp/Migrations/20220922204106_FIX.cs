using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplashUp.Migrations
{
    public partial class FIX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type_contract",
                table: "contract_projects",
                newName: "type_cproject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type_cproject",
                table: "contract_projects",
                newName: "type_contract");
        }
    }
}
