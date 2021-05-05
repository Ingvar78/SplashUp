using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplashUp.Data.Access
{
    public class DbContextManager
    {
        public static IGovDbContext CreateGovContext(string connectionString, ILoggerFactory loggerFactory)
        {
            return new AimDbContext(connectionString, loggerFactory);
        }

	
        public static void InitGovDb(string connectionString, ILoggerFactory loggerFactory)
        {
            try
            {
            }
            catch (Exception ex)
            {
                loggerFactory.CreateLogger<DbContextManager>().LogCritical(ex, ex.Message);
#pragma warning disable CA2200 // Rethrow to preserve stack details
                throw ex;
#pragma warning restore CA2200 // Rethrow to preserve stack details
            }
        }
    }
}
