using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SplashUp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "file_cashes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    zip_file = table.Column<string>(type: "varchar(128)", nullable: true),
                    full_path = table.Column<string>(type: "varchar(256)", nullable: true),
                    base_dir = table.Column<string>(type: "varchar(64)", nullable: true),
                    dirtype = table.Column<string>(type: "varchar(64)", nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    size = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<int>(nullable: false),
                    fz_type = table.Column<int>(nullable: false),
                    modifid_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_file_cashes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nsi_areasons",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    oos_id = table.Column<long>(type: "bigint", nullable: false),
                    code = table.Column<string>(type: "varchar(20)", nullable: true),
                    name = table.Column<string>(type: "varchar(3000)", nullable: true),
                    object_name = table.Column<string>(type: "varchar(350)", nullable: true),
                    type = table.Column<string>(type: "varchar(4)", nullable: true),
                    doc_type = table.Column<string>(type: "jsonb", nullable: true),
                    placing_way = table.Column<string>(type: "jsonb", nullable: true),
                    actual = table.Column<bool>(nullable: false),
                    fz_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nsi_areasons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nsi_etps",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "varchar(20)", nullable: true),
                    name = table.Column<string>(type: "varchar(200)", nullable: true),
                    description = table.Column<string>(type: "varchar(200)", nullable: true),
                    phone = table.Column<string>(type: "varchar(30)", nullable: true),
                    address = table.Column<string>(type: "varchar(50)", nullable: true),
                    email = table.Column<string>(type: "varchar(50)", nullable: true),
                    full_name = table.Column<string>(type: "varchar(2000)", nullable: true),
                    inn = table.Column<string>(type: "varchar(10)", nullable: true),
                    kpp = table.Column<string>(type: "varchar(9)", nullable: true),
                    actual = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nsi_etps", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nsi_file_cashes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    zip_file = table.Column<string>(type: "varchar(128)", nullable: true),
                    full_path = table.Column<string>(type: "varchar(256)", nullable: true),
                    base_dir = table.Column<string>(type: "varchar(64)", nullable: true),
                    dirtype = table.Column<string>(type: "varchar(64)", nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    size = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<int>(nullable: false),
                    fz_type = table.Column<int>(nullable: false),
                    modifid_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nsi_file_cashes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nsi_organizations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reg_number = table.Column<string>(type: "varchar(20)", nullable: true),
                    full_name = table.Column<string>(type: "varchar(2000)", nullable: true),
                    nsi_data = table.Column<string>(type: "jsonb", nullable: true),
                    accounts = table.Column<string>(type: "jsonb", nullable: true),
                    registration_date = table.Column<DateTime>(nullable: false),
                    inn = table.Column<string>(type: "varchar(10)", nullable: true),
                    kpp = table.Column<string>(type: "varchar(20)", nullable: true),
                    ogrn = table.Column<string>(type: "varchar(20)", nullable: true),
                    is_actual = table.Column<bool>(nullable: false),
                    fz_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nsi_organizations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nsi_placing_ways",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    placing_way_id = table.Column<long>(type: "bigint", nullable: false),
                    placing_way_data = table.Column<string>(type: "jsonb", nullable: true),
                    code = table.Column<string>(type: "varchar(20)", nullable: true),
                    name = table.Column<string>(type: "varchar(3000)", nullable: true),
                    sstype = table.Column<int>(nullable: false),
                    type = table.Column<string>(type: "varchar(20)", nullable: true),
                    fz_type = table.Column<int>(nullable: false),
                    actual = table.Column<bool>(nullable: false),
                    is_procedure = table.Column<bool>(nullable: false),
                    is_exclude = table.Column<bool>(nullable: false),
                    is_closing = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nsi_placing_ways", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "file_cashes");

            migrationBuilder.DropTable(
                name: "nsi_areasons");

            migrationBuilder.DropTable(
                name: "nsi_etps");

            migrationBuilder.DropTable(
                name: "nsi_file_cashes");

            migrationBuilder.DropTable(
                name: "nsi_organizations");

            migrationBuilder.DropTable(
                name: "nsi_placing_ways");
        }
    }
}
