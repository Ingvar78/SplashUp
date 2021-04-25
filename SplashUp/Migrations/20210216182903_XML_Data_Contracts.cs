using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SplashUp.Migrations
{
    public partial class XML_Data_Contracts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contracts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contracts");
        }
    }
}
