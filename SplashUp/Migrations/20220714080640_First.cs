using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplashUp.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_nsi_areasons",
                table: "nsi_areasons");

            migrationBuilder.RenameTable(
                name: "nsi_areasons",
                newName: "nsi_a_reasons");

            migrationBuilder.RenameColumn(
                name: "sstype",
                table: "nsi_placing_ways",
                newName: "ss_type");

            migrationBuilder.RenameColumn(
                name: "change_esiadate_time",
                table: "nsi_organizations",
                newName: "change_esia_date_time");

            migrationBuilder.RenameColumn(
                name: "contract_conclusion_on_st83_ch2",
                table: "notifications",
                newName: "contract_conclusion_on_st83ch2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
                table: "nsi_organizations",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "change_esia_date_time",
                table: "nsi_organizations",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modifid_date",
                table: "nsi_file_cashes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "nsi_file_cashes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modifid_date",
                table: "file_cashes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "file_cashes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddPrimaryKey(
                name: "pk_nsi_a_reasons",
                table: "nsi_a_reasons",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_nsi_a_reasons",
                table: "nsi_a_reasons");

            migrationBuilder.RenameTable(
                name: "nsi_a_reasons",
                newName: "nsi_areasons");

            migrationBuilder.RenameColumn(
                name: "ss_type",
                table: "nsi_placing_ways",
                newName: "sstype");

            migrationBuilder.RenameColumn(
                name: "change_esia_date_time",
                table: "nsi_organizations",
                newName: "change_esiadate_time");

            migrationBuilder.RenameColumn(
                name: "contract_conclusion_on_st83ch2",
                table: "notifications",
                newName: "contract_conclusion_on_st83_ch2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
                table: "nsi_organizations",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "change_esiadate_time",
                table: "nsi_organizations",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modifid_date",
                table: "nsi_file_cashes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "nsi_file_cashes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modifid_date",
                table: "file_cashes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "file_cashes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "pk_nsi_areasons",
                table: "nsi_areasons",
                column: "id");
        }
    }
}
