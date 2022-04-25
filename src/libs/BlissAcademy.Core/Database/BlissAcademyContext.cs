using BlissAcademy.Core.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlissAcademy.Core.Database
{
    public class BlissAcademyContext: DbContext
    {

        public DbSet<WishlistProduct> WishlistProducts { get; set; }

        private readonly ILoggerFactory _loggerFactory;

        public BlissAcademyContext(DbContextOptions<BlissAcademyContext> options, ILoggerFactory loggerFactory)
            : base(options)
        {
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null) throw new ArgumentNullException(nameof(optionsBuilder));

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        }
    }
}
