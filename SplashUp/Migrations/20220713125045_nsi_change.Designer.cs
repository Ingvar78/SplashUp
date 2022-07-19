﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SplashUp.Data.Access;

namespace SplashUp.Migrations
{
    [DbContext(typeof(AimDbContext))]
    [Migration("20220713125045_nsi_change")]
    partial class nsi_change
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SplashUp.Data.DB.Contracts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Contract_num")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("contract_num");

                    b.Property<string>("File_name")
                        .HasColumnType("varchar(128)")
                        .HasColumnName("file_name");

                    b.Property<short>("Fz_type")
                        .HasColumnType("smallint")
                        .HasColumnName("fz_type");

                    b.Property<string>("Hash")
                        .HasColumnType("varchar(64)")
                        .HasColumnName("hash");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("publish_date");

                    b.Property<string>("R_body")
                        .HasColumnType("jsonb")
                        .HasColumnName("r_body");

                    b.Property<string>("Type_contract")
                        .HasColumnType("varchar(64)")
                        .HasColumnName("type_contract");

                    b.Property<string>("Xml_body")
                        .HasColumnType("xml")
                        .HasColumnName("xml_body");

                    b.Property<string>("Zip_file")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("zip_file");

                    b.HasKey("Id")
                        .HasName("pk_contracts");

                    b.ToTable("contracts");
                });

            modelBuilder.Entity("SplashUp.Data.DB.FileCashes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BaseDir")
                        .HasColumnType("varchar(64)")
                        .HasColumnName("base_dir");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("date");

                    b.Property<string>("Dirtype")
                        .HasColumnType("varchar(64)")
                        .HasColumnName("dirtype");

                    b.Property<string>("Full_path")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("full_path");

                    b.Property<int>("Fz_type")
                        .HasColumnType("integer")
                        .HasColumnName("fz_type");

                    b.Property<DateTime>("Modifid_date")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modifid_date");

                    b.Property<long>("Size")
                        .HasColumnType("bigint")
                        .HasColumnName("size");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("Zip_file")
                        .HasColumnType("varchar(128)")
                        .HasColumnName("zip_file");

                    b.HasKey("Id")
                        .HasName("pk_file_cashes");

                    b.ToTable("file_cashes");
                });

            modelBuilder.Entity("SplashUp.Data.DB.Notifications", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<short>("AppRating")
                        .HasColumnType("smallint")
                        .HasColumnName("app_rating");

                    b.Property<string>("File_name")
                        .HasColumnType("varchar(128)")
                        .HasColumnName("file_name");

                    b.Property<short>("Fz_type")
                        .HasColumnType("smallint")
                        .HasColumnName("fz_type");

                    b.Property<string>("Hash")
                        .HasColumnType("varchar(64)")
                        .HasColumnName("hash");

                    b.Property<string>("Inn")
                        .HasColumnType("varchar(12)")
                        .HasColumnName("inn");

                    b.Property<string>("JournalNumber")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("journal_number");

                    b.Property<string>("ParticipantInfo")
                        .HasColumnType("jsonb")
                        .HasColumnName("participant_info");

                    b.Property<DateTime>("ProtocolDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("protocol_date");

                    b.Property<string>("ProtocolNum")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("protocol_num");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("publish_date");

                    b.Property<string>("Purchase_num")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("purchase_num");

                    b.Property<string>("R_body")
                        .HasColumnType("jsonb")
                        .HasColumnName("r_body");

                    b.Property<string>("Type_notif")
                        .HasColumnType("varchar(64)")
                        .HasColumnName("type_notif");

                    b.Property<decimal>("W_price")
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("w_price");

                    b.Property<string>("Wname")
                        .HasColumnType("varchar(1024)")
                        .HasColumnName("wname");

                    b.Property<string>("Zip_file")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("zip_file");

                    b.Property<bool>("contractConclusionOnSt83Ch2")
                        .HasColumnType("boolean")
                        .HasColumnName("contract_conclusion_on_st83_ch2");

                    b.HasKey("Id")
                        .HasName("pk_notifications");

                    b.ToTable("notifications");
                });

            modelBuilder.Entity("SplashUp.Data.DB.NsiAbandonedReason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Actual")
                        .HasColumnType("boolean")
                        .HasColumnName("actual");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("code");

                    b.Property<int>("Fz_type")
                        .HasColumnType("integer")
                        .HasColumnName("fz_type");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(3000)")
                        .HasColumnName("name");

                    b.Property<long>("OosId")
                        .HasColumnType("bigint")
                        .HasColumnName("oos_id");

                    b.Property<string>("PlacingWay")
                        .HasColumnType("jsonb")
                        .HasColumnName("placing_way");

                    b.Property<string>("Type")
                        .HasColumnType("varchar(4)")
                        .HasColumnName("type");

                    b.Property<string>("docType")
                        .HasColumnType("jsonb")
                        .HasColumnName("doc_type");

                    b.Property<string>("objectName")
                        .HasColumnType("varchar(350)")
                        .HasColumnName("object_name");

                    b.HasKey("Id")
                        .HasName("pk_nsi_areasons");

                    b.ToTable("nsi_areasons");
                });

            modelBuilder.Entity("SplashUp.Data.DB.NsiEtps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Actual")
                        .HasColumnType("boolean")
                        .HasColumnName("actual");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("address");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("code");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("full_name");

                    b.Property<string>("INN")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("inn");

                    b.Property<string>("KPP")
                        .HasColumnType("varchar(9)")
                        .HasColumnName("kpp");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(30)")
                        .HasColumnName("phone");

                    b.HasKey("Id")
                        .HasName("pk_nsi_etps");

                    b.ToTable("nsi_etps");
                });

            modelBuilder.Entity("SplashUp.Data.DB.NsiFileCashes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BaseDir")
                        .HasColumnType("varchar(64)")
                        .HasColumnName("base_dir");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("date");

                    b.Property<string>("Dirtype")
                        .HasColumnType("varchar(64)")
                        .HasColumnName("dirtype");

                    b.Property<string>("Full_path")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("full_path");

                    b.Property<int>("Fz_type")
                        .HasColumnType("integer")
                        .HasColumnName("fz_type");

                    b.Property<DateTime>("Modifid_date")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modifid_date");

                    b.Property<long>("Size")
                        .HasColumnType("bigint")
                        .HasColumnName("size");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("Zip_file")
                        .HasColumnType("varchar(128)")
                        .HasColumnName("zip_file");

                    b.HasKey("Id")
                        .HasName("pk_nsi_file_cashes");

                    b.ToTable("nsi_file_cashes");
                });

            modelBuilder.Entity("SplashUp.Data.DB.NsiOrganizations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Accounts")
                        .HasColumnType("jsonb")
                        .HasColumnName("accounts");

                    b.Property<string>("FullName")
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("full_name");

                    b.Property<int>("Fz_type")
                        .HasColumnType("integer")
                        .HasColumnName("fz_type");

                    b.Property<string>("Inn")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("inn");

                    b.Property<bool>("IsActual")
                        .HasColumnType("boolean")
                        .HasColumnName("is_actual");

                    b.Property<string>("Kpp")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("kpp");

                    b.Property<string>("NsiData")
                        .HasColumnType("jsonb")
                        .HasColumnName("nsi_data");

                    b.Property<string>("Ogrn")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("ogrn");

                    b.Property<string>("RegNumber")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("reg_number");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("registration_date");

                    b.Property<DateTime>("changeESIADateTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("change_esiadate_time");

                    b.HasKey("Id")
                        .HasName("pk_nsi_organizations");

                    b.ToTable("nsi_organizations");
                });

            modelBuilder.Entity("SplashUp.Data.DB.NsiPlacingWays", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Actual")
                        .HasColumnType("boolean")
                        .HasColumnName("actual");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("code");

                    b.Property<int>("Fz_type")
                        .HasColumnType("integer")
                        .HasColumnName("fz_type");

                    b.Property<bool>("IsClosing")
                        .HasColumnType("boolean")
                        .HasColumnName("is_closing");

                    b.Property<bool>("IsExclude")
                        .HasColumnType("boolean")
                        .HasColumnName("is_exclude");

                    b.Property<bool>("IsProcedure")
                        .HasColumnType("boolean")
                        .HasColumnName("is_procedure");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(3000)")
                        .HasColumnName("name");

                    b.Property<string>("PlacingWayData")
                        .HasColumnType("jsonb")
                        .HasColumnName("placing_way_data");

                    b.Property<long>("PlacingWayId")
                        .HasColumnType("bigint")
                        .HasColumnName("placing_way_id");

                    b.Property<int>("SSType")
                        .HasColumnType("integer")
                        .HasColumnName("sstype");

                    b.Property<string>("Type")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_nsi_placing_ways");

                    b.ToTable("nsi_placing_ways");
                });

            modelBuilder.Entity("SplashUp.Data.DB.Protocols", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("File_name")
                        .HasColumnType("varchar(128)")
                        .HasColumnName("file_name");

                    b.Property<short>("Fz_type")
                        .HasColumnType("smallint")
                        .HasColumnName("fz_type");

                    b.Property<string>("Hash")
                        .HasColumnType("varchar(64)")
                        .HasColumnName("hash");

                    b.Property<string>("Protocol_num")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("protocol_num");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("publish_date");

                    b.Property<string>("Purchase_num")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("purchase_num");

                    b.Property<string>("R_body")
                        .HasColumnType("jsonb")
                        .HasColumnName("r_body");

                    b.Property<string>("Type_protocol")
                        .HasColumnType("varchar(64)")
                        .HasColumnName("type_protocol");

                    b.Property<string>("Zip_file")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("zip_file");

                    b.HasKey("Id")
                        .HasName("pk_protocols");

                    b.ToTable("protocols");
                });
#pragma warning restore 612, 618
        }
    }
}
