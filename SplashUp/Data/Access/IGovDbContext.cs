﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SplashUp.Data.DB;

namespace SplashUp.Data.Access
{
    public interface IGovDbContext : IDisposable
    {
        /// <summary>
        /// Кэш файлов аукционы, протоколы
        /// </summary>
        DbSet<FileCashes> FileCashes { get; set; }

        /// <summary>
        /// Кэш файлов справочников
        /// </summary>
        DbSet<NsiFileCashes> NsiFileCashes { get; set; }

        /// <summary>
        /// Справочник оснований признания процедуры несостоявшейся
        /// </summary>
        DbSet<NsiAbandonedReason> NsiAReasons { get; set; }

        /// <summary>
        /// Справочник: Электронные площадки
        /// </summary>
        DbSet<NsiEtps> NsiEtps { get; set; }

        /// <summary>
        /// Справочник: Способы размещения заказов
        /// </summary>
        DbSet<NsiPlacingWays> NsiPlacingWays { get; set; }

        /// <summary>
        /// Справочник: Организации зарегестрированные в ЕИС
        /// </summary>
        DbSet<NsiOrganizations> NsiOrganizations { get; set; }

        /// <summary>
        /// Все типы извещений по аукционам 44 ФЗ
        /// </summary>
        DbSet<Notifications> Notifications { get; set; }

        /// <summary>
        /// Данные процедур контрактов по 44 ФЗ 
        /// </summary>
        DbSet<Contracts> Contracts { get; set; }

        /// <summary>
        /// Данные протоколов по 44ФЗ
        /// </summary>
        DbSet<Protocols> Protocols { get; set; }

        /// <summary>
        /// Данные проектов контрактов
        /// </summary>
        /// <returns></returns>
        DbSet<ContractProject> ContractProjects { get; set; }
        int SaveChanges();
    }
}
