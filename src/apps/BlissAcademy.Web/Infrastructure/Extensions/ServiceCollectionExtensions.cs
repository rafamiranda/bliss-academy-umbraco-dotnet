using BlissAcademy.Core.Database;
using BlissAcademy.Core.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlissAcademy.Web.Infrastructure.Extensions
{

    namespace Microsoft.Extensions.DependencyInjection
    {
        public static class ServiceCollectionExtensions
        {
            public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
            {
                services.AddDbContext<BlissAcademyContext>(opts =>
                {
                    var connectionString = configuration.GetConnectionString("umbracoDbDSN");
                    var migrationAssembly = typeof(BlissAcademyContext).Assembly.GetName().Name;

                    opts.UseSqlServer(connectionString, sql =>
                    {
                        sql.MigrationsAssembly(migrationAssembly);
                        sql.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    });
                });
            }

            public static void AddServiceOptions(this IServiceCollection services, IConfiguration configuration)
            {
                services.AddOptions();
                services.Configure<DatabaseInitializationOptions>(configuration.GetSection("DatabaseInitialization"));
            }
        }
    }
}
