using CLINICAL.Application.Interface;
using CLINICAL.Persistence.Context;
using CLINICAL.Persistence.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Persistence.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDbContext>();
            services.AddScoped<IAnalysisDal, EfAnalysisDal>();
            return services;
        }
    }
}
