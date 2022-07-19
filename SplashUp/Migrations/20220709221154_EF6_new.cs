using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplashUp.Migrations
{
    public partial class EF6_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_protocols",
                table: "protocols");

            migrationBuilder.DropPrimaryKey(
                name: "pk_notifications",
                table: "notifications");

            migrationBuilder.DropPrimaryKey(
                name: "pk_contracts",
                table: "contracts");

            migrationBuilder.DropPrimaryKey(
                name: "pk_nsi_placing_ways",
                table: "nsi_placing_ways");

            migrationBuilder.DropPrimaryKey(
                name: "pk_nsi_organizations",
                table: "nsi_organizations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_nsi_file_cashes",
                table: "nsi_file_cashes");

            migrationBuilder.DropPrimaryKey(
                name: "pk_nsi_etps",
                table: "nsi_etps");

            migrationBuilder.DropPrimaryKey(
                name: "pk_nsi_areasons",
                table: "nsi_areasons");

            migrationBuilder.DropPrimaryKey(
                name: "pk_file_cashes",
                table: "file_cashes");

            migrationBuilder.RenameTable(
                name: "protocols",
                newName: "Protocols");

            migrationBuilder.RenameTable(
                name: "notifications",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "contracts",
                newName: "Contracts");

            migrationBuilder.RenameTable(
                name: "nsi_placing_ways",
                newName: "NsiPlacingWays");

            migrationBuilder.RenameTable(
                name: "nsi_organizations",
                newName: "NsiOrganizations");

            migrationBuilder.RenameTable(
                name: "nsi_file_cashes",
                newName: "NsiFileCashes");

            migrationBuilder.RenameTable(
                name: "nsi_etps",
                newName: "NsiEtps");

            migrationBuilder.RenameTable(
                name: "nsi_areasons",
                newName: "NsiAReasons");

            migrationBuilder.RenameTable(
                name: "file_cashes",
                newName: "FileCashes");

            migrationBuilder.RenameColumn(
                name: "zip_file",
                table: "Protocols",
                newName: "Zip_file");

            migrationBuilder.RenameColumn(
                name: "type_protocol",
                table: "Protocols",
                newName: "Type_protocol");

            migrationBuilder.RenameColumn(
                name: "r_body",
                table: "Protocols",
                newName: "R_body");

            migrationBuilder.RenameColumn(
                name: "purchase_num",
                table: "Protocols",
                newName: "Purchase_num");

            migrationBuilder.RenameColumn(
                name: "protocol_num",
                table: "Protocols",
                newName: "Protocol_num");

            migrationBuilder.RenameColumn(
                name: "hash",
                table: "Protocols",
                newName: "Hash");

            migrationBuilder.RenameColumn(
                name: "fz_type",
                table: "Protocols",
                newName: "Fz_type");

            migrationBuilder.RenameColumn(
                name: "file_name",
                table: "Protocols",
                newName: "File_name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Protocols",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "publish_date",
                table: "Protocols",
                newName: "PublishDate");

            migrationBuilder.RenameColumn(
                name: "zip_file",
                table: "Notifications",
                newName: "Zip_file");

            migrationBuilder.RenameColumn(
                name: "wname",
                table: "Notifications",
                newName: "Wname");

            migrationBuilder.RenameColumn(
                name: "w_price",
                table: "Notifications",
                newName: "W_price");

            migrationBuilder.RenameColumn(
                name: "type_notif",
                table: "Notifications",
                newName: "Type_notif");

            migrationBuilder.RenameColumn(
                name: "r_body",
                table: "Notifications",
                newName: "R_body");

            migrationBuilder.RenameColumn(
                name: "purchase_num",
                table: "Notifications",
                newName: "Purchase_num");

            migrationBuilder.RenameColumn(
                name: "inn",
                table: "Notifications",
                newName: "Inn");

            migrationBuilder.RenameColumn(
                name: "hash",
                table: "Notifications",
                newName: "Hash");

            migrationBuilder.RenameColumn(
                name: "fz_type",
                table: "Notifications",
                newName: "Fz_type");

            migrationBuilder.RenameColumn(
                name: "file_name",
                table: "Notifications",
                newName: "File_name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Notifications",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "publish_date",
                table: "Notifications",
                newName: "PublishDate");

            migrationBuilder.RenameColumn(
                name: "protocol_num",
                table: "Notifications",
                newName: "ProtocolNum");

            migrationBuilder.RenameColumn(
                name: "protocol_date",
                table: "Notifications",
                newName: "ProtocolDate");

            migrationBuilder.RenameColumn(
                name: "participant_info",
                table: "Notifications",
                newName: "ParticipantInfo");

            migrationBuilder.RenameColumn(
                name: "journal_number",
                table: "Notifications",
                newName: "JournalNumber");

            migrationBuilder.RenameColumn(
                name: "contract_conclusion_on_st83_ch2",
                table: "Notifications",
                newName: "contractConclusionOnSt83Ch2");

            migrationBuilder.RenameColumn(
                name: "app_rating",
                table: "Notifications",
                newName: "AppRating");

            migrationBuilder.RenameColumn(
                name: "zip_file",
                table: "Contracts",
                newName: "Zip_file");

            migrationBuilder.RenameColumn(
                name: "xml_body",
                table: "Contracts",
                newName: "Xml_body");

            migrationBuilder.RenameColumn(
                name: "type_contract",
                table: "Contracts",
                newName: "Type_contract");

            migrationBuilder.RenameColumn(
                name: "r_body",
                table: "Contracts",
                newName: "R_body");

            migrationBuilder.RenameColumn(
                name: "hash",
                table: "Contracts",
                newName: "Hash");

            migrationBuilder.RenameColumn(
                name: "fz_type",
                table: "Contracts",
                newName: "Fz_type");

            migrationBuilder.RenameColumn(
                name: "file_name",
                table: "Contracts",
                newName: "File_name");

            migrationBuilder.RenameColumn(
                name: "contract_num",
                table: "Contracts",
                newName: "Contract_num");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Contracts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "publish_date",
                table: "Contracts",
                newName: "PublishDate");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "NsiPlacingWays",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "sstype",
                table: "NsiPlacingWays",
                newName: "SSType");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "NsiPlacingWays",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "fz_type",
                table: "NsiPlacingWays",
                newName: "Fz_type");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "NsiPlacingWays",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "actual",
                table: "NsiPlacingWays",
                newName: "Actual");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "NsiPlacingWays",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "placing_way_id",
                table: "NsiPlacingWays",
                newName: "PlacingWayId");

            migrationBuilder.RenameColumn(
                name: "placing_way_data",
                table: "NsiPlacingWays",
                newName: "PlacingWayData");

            migrationBuilder.RenameColumn(
                name: "is_procedure",
                table: "NsiPlacingWays",
                newName: "IsProcedure");

            migrationBuilder.RenameColumn(
                name: "is_exclude",
                table: "NsiPlacingWays",
                newName: "IsExclude");

            migrationBuilder.RenameColumn(
                name: "is_closing",
                table: "NsiPlacingWays",
                newName: "IsClosing");

            migrationBuilder.RenameColumn(
                name: "ogrn",
                table: "NsiOrganizations",
                newName: "Ogrn");

            migrationBuilder.RenameColumn(
                name: "kpp",
                table: "NsiOrganizations",
                newName: "Kpp");

            migrationBuilder.RenameColumn(
                name: "inn",
                table: "NsiOrganizations",
                newName: "Inn");

            migrationBuilder.RenameColumn(
                name: "fz_type",
                table: "NsiOrganizations",
                newName: "Fz_type");

            migrationBuilder.RenameColumn(
                name: "accounts",
                table: "NsiOrganizations",
                newName: "Accounts");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "NsiOrganizations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "registration_date",
                table: "NsiOrganizations",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "reg_number",
                table: "NsiOrganizations",
                newName: "RegNumber");

            migrationBuilder.RenameColumn(
                name: "nsi_data",
                table: "NsiOrganizations",
                newName: "NsiData");

            migrationBuilder.RenameColumn(
                name: "is_actual",
                table: "NsiOrganizations",
                newName: "IsActual");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "NsiOrganizations",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "zip_file",
                table: "NsiFileCashes",
                newName: "Zip_file");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "NsiFileCashes",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "size",
                table: "NsiFileCashes",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "modifid_date",
                table: "NsiFileCashes",
                newName: "Modifid_date");

            migrationBuilder.RenameColumn(
                name: "fz_type",
                table: "NsiFileCashes",
                newName: "Fz_type");

            migrationBuilder.RenameColumn(
                name: "full_path",
                table: "NsiFileCashes",
                newName: "Full_path");

            migrationBuilder.RenameColumn(
                name: "dirtype",
                table: "NsiFileCashes",
                newName: "Dirtype");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "NsiFileCashes",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "NsiFileCashes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "base_dir",
                table: "NsiFileCashes",
                newName: "BaseDir");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "NsiEtps",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "NsiEtps",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "kpp",
                table: "NsiEtps",
                newName: "KPP");

            migrationBuilder.RenameColumn(
                name: "inn",
                table: "NsiEtps",
                newName: "INN");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "NsiEtps",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "NsiEtps",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "NsiEtps",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "NsiEtps",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "actual",
                table: "NsiEtps",
                newName: "Actual");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "NsiEtps",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "NsiEtps",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "NsiAReasons",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "NsiAReasons",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "fz_type",
                table: "NsiAReasons",
                newName: "Fz_type");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "NsiAReasons",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "actual",
                table: "NsiAReasons",
                newName: "Actual");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "NsiAReasons",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "placing_way",
                table: "NsiAReasons",
                newName: "PlacingWay");

            migrationBuilder.RenameColumn(
                name: "oos_id",
                table: "NsiAReasons",
                newName: "OosId");

            migrationBuilder.RenameColumn(
                name: "object_name",
                table: "NsiAReasons",
                newName: "objectName");

            migrationBuilder.RenameColumn(
                name: "doc_type",
                table: "NsiAReasons",
                newName: "docType");

            migrationBuilder.RenameColumn(
                name: "zip_file",
                table: "FileCashes",
                newName: "Zip_file");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "FileCashes",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "size",
                table: "FileCashes",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "modifid_date",
                table: "FileCashes",
                newName: "Modifid_date");

            migrationBuilder.RenameColumn(
                name: "fz_type",
                table: "FileCashes",
                newName: "Fz_type");

            migrationBuilder.RenameColumn(
                name: "full_path",
                table: "FileCashes",
                newName: "Full_path");

            migrationBuilder.RenameColumn(
                name: "dirtype",
                table: "FileCashes",
                newName: "Dirtype");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "FileCashes",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "FileCashes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "base_dir",
                table: "FileCashes",
                newName: "BaseDir");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "NsiOrganizations",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modifid_date",
                table: "NsiFileCashes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "NsiFileCashes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modifid_date",
                table: "FileCashes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "FileCashes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Protocols",
                table: "Protocols",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NsiPlacingWays",
                table: "NsiPlacingWays",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NsiOrganizations",
                table: "NsiOrganizations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NsiFileCashes",
                table: "NsiFileCashes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NsiEtps",
                table: "NsiEtps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NsiAReasons",
                table: "NsiAReasons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileCashes",
                table: "FileCashes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Protocols",
                table: "Protocols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NsiPlacingWays",
                table: "NsiPlacingWays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NsiOrganizations",
                table: "NsiOrganizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NsiFileCashes",
                table: "NsiFileCashes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NsiEtps",
                table: "NsiEtps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NsiAReasons",
                table: "NsiAReasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileCashes",
                table: "FileCashes");

            migrationBuilder.RenameTable(
                name: "Protocols",
                newName: "protocols");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "notifications");

            migrationBuilder.RenameTable(
                name: "Contracts",
                newName: "contracts");

            migrationBuilder.RenameTable(
                name: "NsiPlacingWays",
                newName: "nsi_placing_ways");

            migrationBuilder.RenameTable(
                name: "NsiOrganizations",
                newName: "nsi_organizations");

            migrationBuilder.RenameTable(
                name: "NsiFileCashes",
                newName: "nsi_file_cashes");

            migrationBuilder.RenameTable(
                name: "NsiEtps",
                newName: "nsi_etps");

            migrationBuilder.RenameTable(
                name: "NsiAReasons",
                newName: "nsi_areasons");

            migrationBuilder.RenameTable(
                name: "FileCashes",
                newName: "file_cashes");

            migrationBuilder.RenameColumn(
                name: "Zip_file",
                table: "protocols",
                newName: "zip_file");

            migrationBuilder.RenameColumn(
                name: "Type_protocol",
                table: "protocols",
                newName: "type_protocol");

            migrationBuilder.RenameColumn(
                name: "R_body",
                table: "protocols",
                newName: "r_body");

            migrationBuilder.RenameColumn(
                name: "Purchase_num",
                table: "protocols",
                newName: "purchase_num");

            migrationBuilder.RenameColumn(
                name: "Protocol_num",
                table: "protocols",
                newName: "protocol_num");

            migrationBuilder.RenameColumn(
                name: "Hash",
                table: "protocols",
                newName: "hash");

            migrationBuilder.RenameColumn(
                name: "Fz_type",
                table: "protocols",
                newName: "fz_type");

            migrationBuilder.RenameColumn(
                name: "File_name",
                table: "protocols",
                newName: "file_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "protocols",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PublishDate",
                table: "protocols",
                newName: "publish_date");

            migrationBuilder.RenameColumn(
                name: "Zip_file",
                table: "notifications",
                newName: "zip_file");

            migrationBuilder.RenameColumn(
                name: "Wname",
                table: "notifications",
                newName: "wname");

            migrationBuilder.RenameColumn(
                name: "W_price",
                table: "notifications",
                newName: "w_price");

            migrationBuilder.RenameColumn(
                name: "Type_notif",
                table: "notifications",
                newName: "type_notif");

            migrationBuilder.RenameColumn(
                name: "R_body",
                table: "notifications",
                newName: "r_body");

            migrationBuilder.RenameColumn(
                name: "Purchase_num",
                table: "notifications",
                newName: "purchase_num");

            migrationBuilder.RenameColumn(
                name: "Inn",
                table: "notifications",
                newName: "inn");

            migrationBuilder.RenameColumn(
                name: "Hash",
                table: "notifications",
                newName: "hash");

            migrationBuilder.RenameColumn(
                name: "Fz_type",
                table: "notifications",
                newName: "fz_type");

            migrationBuilder.RenameColumn(
                name: "File_name",
                table: "notifications",
                newName: "file_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "notifications",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "contractConclusionOnSt83Ch2",
                table: "notifications",
                newName: "contract_conclusion_on_st83_ch2");

            migrationBuilder.RenameColumn(
                name: "PublishDate",
                table: "notifications",
                newName: "publish_date");

            migrationBuilder.RenameColumn(
                name: "ProtocolNum",
                table: "notifications",
                newName: "protocol_num");

            migrationBuilder.RenameColumn(
                name: "ProtocolDate",
                table: "notifications",
                newName: "protocol_date");

            migrationBuilder.RenameColumn(
                name: "ParticipantInfo",
                table: "notifications",
                newName: "participant_info");

            migrationBuilder.RenameColumn(
                name: "JournalNumber",
                table: "notifications",
                newName: "journal_number");

            migrationBuilder.RenameColumn(
                name: "AppRating",
                table: "notifications",
                newName: "app_rating");

            migrationBuilder.RenameColumn(
                name: "Zip_file",
                table: "contracts",
                newName: "zip_file");

            migrationBuilder.RenameColumn(
                name: "Xml_body",
                table: "contracts",
                newName: "xml_body");

            migrationBuilder.RenameColumn(
                name: "Type_contract",
                table: "contracts",
                newName: "type_contract");

            migrationBuilder.RenameColumn(
                name: "R_body",
                table: "contracts",
                newName: "r_body");

            migrationBuilder.RenameColumn(
                name: "Hash",
                table: "contracts",
                newName: "hash");

            migrationBuilder.RenameColumn(
                name: "Fz_type",
                table: "contracts",
                newName: "fz_type");

            migrationBuilder.RenameColumn(
                name: "File_name",
                table: "contracts",
                newName: "file_name");

            migrationBuilder.RenameColumn(
                name: "Contract_num",
                table: "contracts",
                newName: "contract_num");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "contracts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PublishDate",
                table: "contracts",
                newName: "publish_date");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "nsi_placing_ways",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "SSType",
                table: "nsi_placing_ways",
                newName: "sstype");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "nsi_placing_ways",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Fz_type",
                table: "nsi_placing_ways",
                newName: "fz_type");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "nsi_placing_ways",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Actual",
                table: "nsi_placing_ways",
                newName: "actual");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "nsi_placing_ways",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PlacingWayId",
                table: "nsi_placing_ways",
                newName: "placing_way_id");

            migrationBuilder.RenameColumn(
                name: "PlacingWayData",
                table: "nsi_placing_ways",
                newName: "placing_way_data");

            migrationBuilder.RenameColumn(
                name: "IsProcedure",
                table: "nsi_placing_ways",
                newName: "is_procedure");

            migrationBuilder.RenameColumn(
                name: "IsExclude",
                table: "nsi_placing_ways",
                newName: "is_exclude");

            migrationBuilder.RenameColumn(
                name: "IsClosing",
                table: "nsi_placing_ways",
                newName: "is_closing");

            migrationBuilder.RenameColumn(
                name: "Ogrn",
                table: "nsi_organizations",
                newName: "ogrn");

            migrationBuilder.RenameColumn(
                name: "Kpp",
                table: "nsi_organizations",
                newName: "kpp");

            migrationBuilder.RenameColumn(
                name: "Inn",
                table: "nsi_organizations",
                newName: "inn");

            migrationBuilder.RenameColumn(
                name: "Fz_type",
                table: "nsi_organizations",
                newName: "fz_type");

            migrationBuilder.RenameColumn(
                name: "Accounts",
                table: "nsi_organizations",
                newName: "accounts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "nsi_organizations",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "nsi_organizations",
                newName: "registration_date");

            migrationBuilder.RenameColumn(
                name: "RegNumber",
                table: "nsi_organizations",
                newName: "reg_number");

            migrationBuilder.RenameColumn(
                name: "NsiData",
                table: "nsi_organizations",
                newName: "nsi_data");

            migrationBuilder.RenameColumn(
                name: "IsActual",
                table: "nsi_organizations",
                newName: "is_actual");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "nsi_organizations",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "Zip_file",
                table: "nsi_file_cashes",
                newName: "zip_file");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "nsi_file_cashes",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "nsi_file_cashes",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Modifid_date",
                table: "nsi_file_cashes",
                newName: "modifid_date");

            migrationBuilder.RenameColumn(
                name: "Fz_type",
                table: "nsi_file_cashes",
                newName: "fz_type");

            migrationBuilder.RenameColumn(
                name: "Full_path",
                table: "nsi_file_cashes",
                newName: "full_path");

            migrationBuilder.RenameColumn(
                name: "Dirtype",
                table: "nsi_file_cashes",
                newName: "dirtype");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "nsi_file_cashes",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "nsi_file_cashes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "BaseDir",
                table: "nsi_file_cashes",
                newName: "base_dir");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "nsi_etps",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "nsi_etps",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "KPP",
                table: "nsi_etps",
                newName: "kpp");

            migrationBuilder.RenameColumn(
                name: "INN",
                table: "nsi_etps",
                newName: "inn");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "nsi_etps",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "nsi_etps",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "nsi_etps",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "nsi_etps",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Actual",
                table: "nsi_etps",
                newName: "actual");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "nsi_etps",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "nsi_etps",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "nsi_areasons",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "nsi_areasons",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Fz_type",
                table: "nsi_areasons",
                newName: "fz_type");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "nsi_areasons",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Actual",
                table: "nsi_areasons",
                newName: "actual");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "nsi_areasons",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "objectName",
                table: "nsi_areasons",
                newName: "object_name");

            migrationBuilder.RenameColumn(
                name: "docType",
                table: "nsi_areasons",
                newName: "doc_type");

            migrationBuilder.RenameColumn(
                name: "PlacingWay",
                table: "nsi_areasons",
                newName: "placing_way");

            migrationBuilder.RenameColumn(
                name: "OosId",
                table: "nsi_areasons",
                newName: "oos_id");

            migrationBuilder.RenameColumn(
                name: "Zip_file",
                table: "file_cashes",
                newName: "zip_file");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "file_cashes",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "file_cashes",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Modifid_date",
                table: "file_cashes",
                newName: "modifid_date");

            migrationBuilder.RenameColumn(
                name: "Fz_type",
                table: "file_cashes",
                newName: "fz_type");

            migrationBuilder.RenameColumn(
                name: "Full_path",
                table: "file_cashes",
                newName: "full_path");

            migrationBuilder.RenameColumn(
                name: "Dirtype",
                table: "file_cashes",
                newName: "dirtype");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "file_cashes",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "file_cashes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "BaseDir",
                table: "file_cashes",
                newName: "base_dir");

            migrationBuilder.AlterColumn<DateTime>(
                name: "registration_date",
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
                name: "pk_protocols",
                table: "protocols",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_notifications",
                table: "notifications",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_contracts",
                table: "contracts",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_nsi_placing_ways",
                table: "nsi_placing_ways",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_nsi_organizations",
                table: "nsi_organizations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_nsi_file_cashes",
                table: "nsi_file_cashes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_nsi_etps",
                table: "nsi_etps",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_nsi_areasons",
                table: "nsi_areasons",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_file_cashes",
                table: "file_cashes",
                column: "id");
        }
    }
}
