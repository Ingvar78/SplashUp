using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SplashUp.Migrations
{
    public partial class CodeFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contract_projects",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    contract_num = table.Column<string>(type: "varchar(20)", nullable: true),
                    purchase_num = table.Column<string>(type: "text", nullable: true),
                    r_body = table.Column<string>(type: "jsonb", nullable: true),
                    xml_body = table.Column<string>(type: "xml", nullable: true),
                    hash = table.Column<string>(type: "varchar(64)", nullable: true),
                    type_cproject = table.Column<string>(type: "varchar(64)", nullable: true),
                    zip_file = table.Column<string>(type: "varchar(256)", nullable: true),
                    file_name = table.Column<string>(type: "varchar(128)", nullable: true),
                    fz_type = table.Column<short>(type: "smallint", nullable: false),
                    publish_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contract_projects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contracts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    contract_num = table.Column<string>(type: "varchar(20)", nullable: true),
                    r_body = table.Column<string>(type: "jsonb", nullable: true),
                    xml_body = table.Column<string>(type: "xml", nullable: true),
                    hash = table.Column<string>(type: "varchar(64)", nullable: true),
                    type_contract = table.Column<string>(type: "varchar(64)", nullable: true),
                    zip_file = table.Column<string>(type: "varchar(256)", nullable: true),
                    file_name = table.Column<string>(type: "varchar(128)", nullable: true),
                    fz_type = table.Column<short>(type: "smallint", nullable: false),
                    publish_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contracts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contracts_procedures",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    contract_num = table.Column<string>(type: "varchar(20)", nullable: true),
                    doc_reg_number = table.Column<string>(type: "text", nullable: true),
                    r_body = table.Column<string>(type: "jsonb", nullable: true),
                    xml_body = table.Column<string>(type: "xml", nullable: true),
                    hash = table.Column<string>(type: "varchar(64)", nullable: true),
                    type_contract = table.Column<string>(type: "varchar(64)", nullable: true),
                    zip_file = table.Column<string>(type: "varchar(256)", nullable: true),
                    file_name = table.Column<string>(type: "varchar(128)", nullable: true),
                    fz_type = table.Column<short>(type: "smallint", nullable: false),
                    cancel_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    publish_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contracts_procedures", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "file_cashes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    zip_file = table.Column<string>(type: "varchar(128)", nullable: true),
                    full_path = table.Column<string>(type: "varchar(256)", nullable: true),
                    base_dir = table.Column<string>(type: "varchar(64)", nullable: true),
                    dirtype = table.Column<string>(type: "varchar(64)", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    size = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    fz_type = table.Column<int>(type: "integer", nullable: false),
                    modifid_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_file_cashes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    purchase_num = table.Column<string>(type: "varchar(20)", nullable: true),
                    protocol_num = table.Column<string>(type: "varchar(100)", nullable: true),
                    r_body = table.Column<string>(type: "jsonb", nullable: true),
                    xml_body = table.Column<string>(type: "xml", nullable: true),
                    inn = table.Column<string>(type: "varchar(12)", nullable: true),
                    wname = table.Column<string>(type: "varchar(1024)", nullable: true),
                    participant_info = table.Column<string>(type: "jsonb", nullable: true),
                    app_rating = table.Column<short>(type: "smallint", nullable: false),
                    contract_conclusion_on_st83ch2 = table.Column<bool>(type: "boolean", nullable: false),
                    journal_number = table.Column<string>(type: "varchar(100)", nullable: true),
                    w_price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    hash = table.Column<string>(type: "varchar(64)", nullable: true),
                    type_notif = table.Column<string>(type: "varchar(64)", nullable: true),
                    zip_file = table.Column<string>(type: "varchar(256)", nullable: true),
                    file_name = table.Column<string>(type: "varchar(128)", nullable: true),
                    fz_type = table.Column<short>(type: "smallint", nullable: false),
                    protocol_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    publish_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notifications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nsi_a_reasons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    oos_id = table.Column<long>(type: "bigint", nullable: false),
                    code = table.Column<string>(type: "varchar(20)", nullable: true),
                    name = table.Column<string>(type: "varchar(3000)", nullable: true),
                    object_name = table.Column<string>(type: "varchar(350)", nullable: true),
                    type = table.Column<string>(type: "varchar(4)", nullable: true),
                    doc_type = table.Column<string>(type: "jsonb", nullable: true),
                    placing_way = table.Column<string>(type: "jsonb", nullable: true),
                    actual = table.Column<bool>(type: "boolean", nullable: false),
                    fz_type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nsi_a_reasons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nsi_etps",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
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
                    actual = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nsi_etps", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nsi_file_cashes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    zip_file = table.Column<string>(type: "varchar(128)", nullable: true),
                    full_path = table.Column<string>(type: "varchar(256)", nullable: true),
                    base_dir = table.Column<string>(type: "varchar(64)", nullable: true),
                    dirtype = table.Column<string>(type: "varchar(64)", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    size = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    fz_type = table.Column<int>(type: "integer", nullable: false),
                    modifid_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nsi_file_cashes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nsi_organizations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reg_number = table.Column<string>(type: "varchar(20)", nullable: true),
                    full_name = table.Column<string>(type: "varchar(2000)", nullable: true),
                    nsi_data = table.Column<string>(type: "jsonb", nullable: true),
                    accounts = table.Column<string>(type: "jsonb", nullable: true),
                    registration_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    change_esia_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    inn = table.Column<string>(type: "varchar(10)", nullable: true),
                    kpp = table.Column<string>(type: "varchar(20)", nullable: true),
                    ogrn = table.Column<string>(type: "varchar(20)", nullable: true),
                    is_actual = table.Column<bool>(type: "boolean", nullable: false),
                    fz_type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nsi_organizations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nsi_placing_ways",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    placing_way_id = table.Column<long>(type: "bigint", nullable: false),
                    placing_way_data = table.Column<string>(type: "jsonb", nullable: true),
                    code = table.Column<string>(type: "varchar(20)", nullable: true),
                    name = table.Column<string>(type: "varchar(3000)", nullable: true),
                    ss_type = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<string>(type: "varchar(20)", nullable: true),
                    fz_type = table.Column<int>(type: "integer", nullable: false),
                    actual = table.Column<bool>(type: "boolean", nullable: false),
                    is_procedure = table.Column<bool>(type: "boolean", nullable: false),
                    is_exclude = table.Column<bool>(type: "boolean", nullable: false),
                    is_closing = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nsi_placing_ways", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "protocols",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    purchase_num = table.Column<string>(type: "varchar(20)", nullable: true),
                    protocol_num = table.Column<string>(type: "varchar(100)", nullable: true),
                    r_body = table.Column<string>(type: "jsonb", nullable: true),
                    xml_body = table.Column<string>(type: "xml", nullable: true),
                    hash = table.Column<string>(type: "varchar(64)", nullable: true),
                    type_protocol = table.Column<string>(type: "varchar(64)", nullable: true),
                    zip_file = table.Column<string>(type: "varchar(256)", nullable: true),
                    file_name = table.Column<string>(type: "varchar(128)", nullable: true),
                    fz_type = table.Column<short>(type: "smallint", nullable: false),
                    publish_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_protocols", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    inn = table.Column<string>(type: "varchar(12)", nullable: true),
                    kpp = table.Column<string>(type: "varchar(20)", nullable: true),
                    ogrn = table.Column<string>(type: "text", nullable: true),
                    oktmo = table.Column<string>(type: "jsonb", nullable: true),
                    okpo = table.Column<string>(type: "varchar(20)", nullable: true),
                    full_name = table.Column<string>(type: "varchar(2048)", nullable: true),
                    okopf = table.Column<string>(type: "varchar(5)", nullable: true),
                    is_ip = table.Column<bool>(type: "boolean", nullable: false),
                    registration_date = table.Column<DateTime>(type: "date", nullable: false),
                    post_address = table.Column<string>(type: "varchar(2048)", nullable: true),
                    contact_phone = table.Column<string>(type: "varchar(2048)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_suppliers", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contract_projects");

            migrationBuilder.DropTable(
                name: "contracts");

            migrationBuilder.DropTable(
                name: "contracts_procedures");

            migrationBuilder.DropTable(
                name: "file_cashes");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "nsi_a_reasons");

            migrationBuilder.DropTable(
                name: "nsi_etps");

            migrationBuilder.DropTable(
                name: "nsi_file_cashes");

            migrationBuilder.DropTable(
                name: "nsi_organizations");

            migrationBuilder.DropTable(
                name: "nsi_placing_ways");

            migrationBuilder.DropTable(
                name: "protocols");

            migrationBuilder.DropTable(
                name: "suppliers");
        }
    }
}
