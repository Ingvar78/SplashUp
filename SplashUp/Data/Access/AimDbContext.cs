﻿using SplashUp.Data.DB;
using SplashUp.Data.Extention;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplashUp.Data.Access
{
    internal class AimDbContext : DbContext, IGovDbContext
    {
        private readonly string _connectionString;
        private readonly ILoggerFactory _loggerFactory;
        public AimDbContext(string connectionString, ILoggerFactory loggerFactory)
        {
            _connectionString = connectionString;
            _loggerFactory = loggerFactory;
        }


        public AimDbContext(DbContextOptions<AimDbContext> options)
        : base(options)
        {
            //For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
        }

        //public GovDbContext()
        //{
        //    //Для миграции   
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if true && DEBUG
            optionsBuilder.UseLoggerFactory(_loggerFactory);
#endif
            //optionsBuilder.UseNpgsql("Host=192.168.1.15;Port=5432;Database=AimDbEF6;Username=zak;Password=Zaq1Xsw2;Pooling=True").UseSnakeCaseNamingConvention();
            optionsBuilder.UseNpgsql(_connectionString).UseSnakeCaseNamingConvention(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.UsePostgresConventions();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<FileCashes> FileCashes { get; set; }
        public DbSet<NsiFileCashes> NsiFileCashes { get; set; }
        public DbSet<NsiAbandonedReason> NsiAReasons { get; set; }
        public DbSet<NsiEtps> NsiEtps { get; set; }

        public DbSet<NsiPlacingWays> NsiPlacingWays { get; set; }
        public DbSet<NsiOrganizations> NsiOrganizations { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Contracts> Contracts { get; set; }
        public DbSet<Protocols> Protocols { get; set; }
        int IGovDbContext.SaveChanges()
        {
            return this.SaveChangesInternal();
        }

        private int SaveChangesInternal()
        {
            var result = base.SaveChanges();
            return result;
        }

    }
}
