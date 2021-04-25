using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SplashUp.Migrations
{
    public partial class Notification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    purchase_num = table.Column<string>(type: "varchar(20)", nullable: true),
                    protocol_num = table.Column<string>(type: "varchar(100)", nullable: true),
                    inn = table.Column<string>(type: "varchar(12)", nullable: true),
                    wname = table.Column<string>(type: "varchar(1024)", nullable: true),
                    participant_info = table.Column<string>(type: "jsonb", nullable: true),
                    app_rating = table.Column<short>(nullable: false),
                    contract_conclusion = table.Column<string>(type: "varchar(4)", nullable: true),
                    journal_number = table.Column<string>(type: "varchar(100)", nullable: true),
                    w_price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    r_body = table.Column<string>(type: "jsonb", nullable: true),
                    type_notif = table.Column<string>(type: "varchar(64)", nullable: true),
                    zip_file = table.Column<string>(type: "varchar(128)", nullable: true),
                    file_name = table.Column<string>(type: "varchar(128)", nullable: true),
                    fz_type = table.Column<short>(type: "smallint", nullable: false),
                    protocol_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    publish_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notifications", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notifications");
        }
    }
}
