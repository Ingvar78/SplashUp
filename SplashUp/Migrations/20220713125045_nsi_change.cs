using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SplashUp.Migrations
{
    public partial class nsi_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "change_esiadate_time",
                table: "nsi_organizations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "change_esiadate_time",
                table: "nsi_organizations");
        }
    }
}
