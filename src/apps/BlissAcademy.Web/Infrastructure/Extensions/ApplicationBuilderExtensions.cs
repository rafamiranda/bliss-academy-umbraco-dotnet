using BlissAcademy.Core.Database;
using BlissAcademy.Core.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static void InitializeDb(this IApplicationBuilder app)
        {
            if (app is null) throw new ArgumentNullException(nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var opts = scope.ServiceProvider.GetRequiredService<IOptions<DatabaseInitializationOptions>>().Value;
            var logger = scope.ServiceProvider.GetRequiredService<ILogger>().ForContext("SourceContext", "BlissAcademy.DatabaseInitialization");
            InitializeBlissAcademyDb(scope, opts, logger);
        }

        private static void InitializeBlissAcademyDb(IServiceScope scope, DatabaseInitializationOptions opts, ILogger logger)
        {
            logger.Information("Checking config for AspNetCoreIdentity Database Initialization ...");
            var ctx = scope.ServiceProvider.GetRequiredService<BlissAcademyContext>();

            if (opts.BlissAcademy.MigrationsEnabled)
            {
                logger.Information("Will try to apply migrations on AspNetIdentity DbContext");
                ctx.Database.Migrate();
            }
        }
    }
}
