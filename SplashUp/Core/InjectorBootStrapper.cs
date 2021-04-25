using SplashUp.Core.Interfaces;
using SplashUp.Core.Services;
using SplashUp.Data.Managers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplashUp.Core
{
    public class InjectorBootStrapper
    {
            public static void RegisterServices(IServiceCollection services)
            {
            
            services.AddTransient<IGovDbManager, GovDbManager>();
            services.AddTransient<IDataServices, DataServices>();
            services.AddTransient<JobsRegister>();
        }


    }
}
