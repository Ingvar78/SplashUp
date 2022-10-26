using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplashUp.Migrations
{
    public partial class CancelDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "cancel_date",
                table: "contracts_procedures",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cancel_date",
                table: "contracts_procedures");
        }
    }
}
