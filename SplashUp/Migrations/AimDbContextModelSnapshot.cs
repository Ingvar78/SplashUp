﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SplashUp.Data.Access;

#nullable disable

namespace SplashUp.Migrations
{
    [DbContext(typeof(AimDbContext))]
    partial class AimDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SplashUp.Data.DB.Contracts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Contract_num")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("File_name")
                        .HasColumnType("varchar(128)");

                    b.Property<short>("Fz_type")
                        .HasColumnType("smallint");

                    b.Property<string>("Hash")
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("R_body")
                        .HasColumnType("jsonb");

                    b.Property<string>("Type_contract")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Xml_body")
                        .HasColumnType("xml");

                    b.Property<string>("Zip_file")
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("SplashUp.Data.DB.FileCashes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BaseDir")
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Dirtype")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Full_path")
                        .HasColumnType("varchar(256)");

                    b.Property<int>("Fz_type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Modifid_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Zip_file")
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.ToTable("FileCashes");
                });

            modelBuilder.Entity("SplashUp.Data.DB.Notifications", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<short>("AppRating")
                        .HasColumnType("smallint");

                    b.Property<string>("File_name")
                        .HasColumnType("varchar(128)");

                    b.Property<short>("Fz_type")
                        .HasColumnType("smallint");

                    b.Property<string>("Hash")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Inn")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("JournalNumber")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ParticipantInfo")
                        .HasColumnType("jsonb");

                    b.Property<DateTime>("ProtocolDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ProtocolNum")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Purchase_num")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("R_body")
                        .HasColumnType("jsonb");

                    b.Property<string>("Type_notif")
                        .HasColumnType("varchar(64)");

                    b.Property<decimal>("W_price")
                        .HasColumnType("numeric(18,2)");

                    b.Property<string>("Wname")
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("Zip_file")
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("contractConclusionOnSt83Ch2")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("SplashUp.Data.DB.NsiAbandonedReason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Actual")
                        .HasColumnType("boolean");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Fz_type")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(3000)");

                    b.Property<long>("OosId")
                        .HasColumnType("bigint");

                    b.Property<string>("PlacingWay")
                        .HasColumnType("jsonb");

                    b.Property<string>("Type")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("docType")
                        .HasColumnType("jsonb");

                    b.Property<string>("objectName")
                        .HasColumnType("varchar(350)");

                    b.HasKey("Id");

                    b.ToTable("NsiAReasons");
                });

            modelBuilder.Entity("SplashUp.Data.DB.NsiEtps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Actual")
                        .HasColumnType("boolean");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FullName")
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("INN")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("KPP")
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("NsiEtps");
                });

            modelBuilder.Entity("SplashUp.Data.DB.NsiFileCashes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BaseDir")
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Dirtype")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Full_path")
                        .HasColumnType("varchar(256)");

                    b.Property<int>("Fz_type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Modifid_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Zip_file")
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.ToTable("NsiFileCashes");
                });

            modelBuilder.Entity("SplashUp.Data.DB.NsiOrganizations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Accounts")
                        .HasColumnType("jsonb");

                    b.Property<string>("FullName")
                        .HasColumnType("varchar(2000)");

                    b.Property<int>("Fz_type")
                        .HasColumnType("integer");

                    b.Property<string>("Inn")
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("IsActual")
                        .HasColumnType("boolean");

                    b.Property<string>("Kpp")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("NsiData")
                        .HasColumnType("jsonb");

                    b.Property<string>("Ogrn")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("RegNumber")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("NsiOrganizations");
                });

            modelBuilder.Entity("SplashUp.Data.DB.NsiPlacingWays", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Actual")
                        .HasColumnType("boolean");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Fz_type")
                        .HasColumnType("integer");

                    b.Property<bool>("IsClosing")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsExclude")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsProcedure")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(3000)");

                    b.Property<string>("PlacingWayData")
                        .HasColumnType("jsonb");

                    b.Property<long>("PlacingWayId")
                        .HasColumnType("bigint");

                    b.Property<int>("SSType")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("NsiPlacingWays");
                });

            modelBuilder.Entity("SplashUp.Data.DB.Protocols", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("File_name")
                        .HasColumnType("varchar(128)");

                    b.Property<short>("Fz_type")
                        .HasColumnType("smallint");

                    b.Property<string>("Hash")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Protocol_num")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Purchase_num")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("R_body")
                        .HasColumnType("jsonb");

                    b.Property<string>("Type_protocol")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Zip_file")
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Protocols");
                });
#pragma warning restore 612, 618
        }
    }
}
