using Microsoft.EntityFrameworkCore.Migrations;

namespace SplashUp.Migrations
{
    public partial class XML_Data_Hash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "hash",
                table: "notifications",
                type: "varchar(64)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hash",
                table: "notifications");
        }
    }
}
