using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplashUp.Migrations
{
    public partial class DocRegNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "doc_reg_number",
                table: "contracts_procedures",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "doc_reg_number",
                table: "contracts_procedures");
        }
    }
}
