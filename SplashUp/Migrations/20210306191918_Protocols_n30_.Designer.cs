﻿// <auto-generated />
using System;
using SplashUp.Data.Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SplashUp.Migrations
{
    [DbContext(typeof(GovDbContext))]
    [Migration("20210306191918_Protocols_n30_")]
    partial class Protocols_n30_
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SplashUp.Data.DB.Contracts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Contract_num")
                        .HasColumnName("contract_num")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("File_name")
                        .HasColumnName("file_name")
                        .HasColumnType("varchar(128)");

                    b.Property<short>("Fz_type")
                        .HasColumnName("fz_type")
                        .HasColumnType("smallint");

                    b.Property<string>("Hash")
                        .HasColumnName("hash")
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnName("publish_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("R_body")
                        .HasColumnName("r_body")
                        .HasColumnType("jsonb");

                    b.Property<string>("Type_contract")
                        .HasColumnName("type_contract")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Xml_body")
                        .HasColumnName("xml_body")
                        .HasColumnType("xml");

                    b.Property<string>("Zip_file")
                        .HasColumnName("zip_file")
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id")
                        .HasName("pk_contracts");

                    b.ToTable("contracts");
                });

            modelBuilder.Entity("SplashUp.Data.DB.FileCashes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BaseDir")
                        .HasColumnName("base_dir")
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Dirtype")
                        .HasColumnName("dirtype")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Full_path")
                        .HasColumnName("full_path")
                        .HasColumnType("varchar(256)");

                    b.Property<int>("Fz_type")
                        .HasColumnName("fz_type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Modifid_date")
                        .HasColumnName("modifid_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("Size")
                        .HasColumnName("size")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnName("status")
                        .HasColumnType("integer");

                    b.Property<string>("Zip_file")
                        .HasColumnName("zip_file")
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id")
                        .HasName("pk_file_cashes");

                    b.ToTable("file_cashes");
                });

            modelBuilder.Entity("SplashUp.Data.DB.Notifications", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<short>("AppRating")
                        .HasColumnName("app_rating")
                        .HasColumnType("smallint");

                    b.Property<string>("ContractConclusion")
                        .HasColumnName("contract_conclusion")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("File_name")
                        .HasColumnName("file_name")
                        .HasColumnType("varchar(128)");

                    b.Property<short>("Fz_type")
                        .HasColumnName("fz_type")
                        .HasColumnType("smallint");

                    b.Property<string>("Hash")
                        .HasColumnName("hash")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Inn")
                        .HasColumnName("inn")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("JournalNumber")
                        .HasColumnName("journal_number")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ParticipantInfo")
                        .HasColumnName("participant_info")
                        .HasColumnType("jsonb");

                    b.Property<DateTime>("ProtocolDate")
                        .HasColumnName("protocol_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ProtocolNum")
                        .HasColumnName("protocol_num")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnName("publish_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Purchase_num")
                        .HasColumnName("purchase_num")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("R_body")
                        .HasColumnName("r_body")
                        .HasColumnType("jsonb");

                    b.Property<string>("Type_notif")
                        .HasColumnName("type_notif")
                        .HasColumnType("varchar(64)");

                    b.Property<decimal>("W_price")
                        .HasColumnName("w_price")
                        .HasColumnType("numeric(18,2)");

                    b.Property<string>("Wname")
                        .HasColumnName("wname")
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("Xml_body")
                        .HasColumnName("xml_body")
                        .HasColumnType("xml");

                    b.Property<string>("Zip_file")
                        .HasColumnName("zip_file")
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id")
                        .HasName("pk_notifications");

                    b.ToTable("notifications");
                });

            modelBuilder.Entity("SplashUp.Data.DB.NsiAbandonedReason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Actual")
                        .HasColumnName("actual")
                        .HasColumnType("boolean");

                    b.Property<string>("Code")
                        .HasColumnName("code")
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Fz_type")
                        .HasColumnName("fz_type")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(3000)");

                    b.Property<long>("OosId")
                        .HasColumnName("oos_id")
                        .HasColumnType("bigint");

                    b.Property<string>("PlacingWay")
                        .HasColumnName("placing_way")
                        .HasColumnType("jsonb");

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("docType")
                        .HasColumnName("doc_type")
                        .HasColumnType("jsonb");

                    b.Property<string>("objectName")
                        .HasColumnName("object_name")
                        .HasColumnType("varchar(350)");

                    b.HasKey("Id")
                        .HasName("pk_nsi_areasons");

                    b.ToTable("nsi_areasons");
                });

            modelBuilder.Entity("SplashUp.Data.DB.NsiEtps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Actual")
                        .HasColumnName("actual")
                        .HasColumnType("boolean");

                    b.Property<string>("Address")
                        .HasColumnName("address")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Code")
                        .HasColumnName("code")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FullName")
                        .HasColumnName("full_name")
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("INN")
                        .HasColumnName("inn")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("KPP")
                        .HasColumnName("kpp")
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id")
                        .HasName("pk_nsi_etps");

                    b.ToTable("nsi_etps");
                });

            modelBuilder.Entity("SplashUp.Data.DB.NsiFileCashes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BaseDir")
                        .HasColumnName("base_dir")
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Dirtype")
                        .HasColumnName("dirtype")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Full_path")
                        .HasColumnName("full_path")
                        .HasColumnType("varchar(256)");

                    b.Property<int>("Fz_type")
                        .HasColumnName("fz_type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Modifid_date")
                        .HasColumnName("modifid_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("Size")
                        .HasColumnName("size")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnName("status")
                        .HasColumnType("integer");

                    b.Property<string>("Zip_file")
                        .HasColumnName("zip_file")
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id")
                        .HasName("pk_nsi_file_cashes");

                    b.ToTable("nsi_file_cashes");
                });

            modelBuilder.Entity("SplashUp.Data.DB.NsiOrganizations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Accounts")
                        .HasColumnName("accounts")
                        .HasColumnType("jsonb");

                    b.Property<string>("FullName")
                        .HasColumnName("full_name")
                        .HasColumnType("varchar(2000)");

                    b.Property<int>("Fz_type")
                        .HasColumnName("fz_type")
                        .HasColumnType("integer");

                    b.Property<string>("Inn")
                        .HasColumnName("inn")
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("IsActual")
                        .HasColumnName("is_actual")
                        .HasColumnType("boolean");

                    b.Property<string>("Kpp")
                        .HasColumnName("kpp")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("NsiData")
                        .HasColumnName("nsi_data")
                        .HasColumnType("jsonb");

                    b.Property<string>("Ogrn")
                        .HasColumnName("ogrn")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("RegNumber")
                        .HasColumnName("reg_number")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnName("registration_date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id")
                        .HasName("pk_nsi_organizations");

                    b.ToTable("nsi_organizations");
                });

            modelBuilder.Entity("SplashUp.Data.DB.NsiPlacingWays", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Actual")
                        .HasColumnName("actual")
                        .HasColumnType("boolean");

                    b.Property<string>("Code")
                        .HasColumnName("code")
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Fz_type")
                        .HasColumnName("fz_type")
                        .HasColumnType("integer");

                    b.Property<bool>("IsClosing")
                        .HasColumnName("is_closing")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsExclude")
                        .HasColumnName("is_exclude")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsProcedure")
                        .HasColumnName("is_procedure")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(3000)");

                    b.Property<string>("PlacingWayData")
                        .HasColumnName("placing_way_data")
                        .HasColumnType("jsonb");

                    b.Property<long>("PlacingWayId")
                        .HasColumnName("placing_way_id")
                        .HasColumnType("bigint");

                    b.Property<int>("SSType")
                        .HasColumnName("sstype")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id")
                        .HasName("pk_nsi_placing_ways");

                    b.ToTable("nsi_placing_ways");
                });

            modelBuilder.Entity("SplashUp.Data.DB.Protocols", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("File_name")
                        .HasColumnName("file_name")
                        .HasColumnType("varchar(128)");

                    b.Property<short>("Fz_type")
                        .HasColumnName("fz_type")
                        .HasColumnType("smallint");

                    b.Property<string>("Hash")
                        .HasColumnName("hash")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Protocol_num")
                        .HasColumnName("protocol_num")
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnName("publish_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Purchase_num")
                        .HasColumnName("purchase_num")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("R_body")
                        .HasColumnName("r_body")
                        .HasColumnType("jsonb");

                    b.Property<string>("Type_protocol")
                        .HasColumnName("type_protocol")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Xml_body")
                        .HasColumnName("xml_body")
                        .HasColumnType("xml");

                    b.Property<string>("Zip_file")
                        .HasColumnName("zip_file")
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id")
                        .HasName("pk_protocols");

                    b.ToTable("protocols");
                });
#pragma warning restore 612, 618
        }
    }
}
