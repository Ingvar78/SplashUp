using Microsoft.EntityFrameworkCore.Migrations;

namespace SplashUp.Migrations
{
    public partial class XML_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "xml_body",
                table: "notifications",
                type: "xml",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "xml_body",
                table: "notifications");
        }
    }
}
