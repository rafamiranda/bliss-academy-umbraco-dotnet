﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlissAcademy.Core.Infrastructure.Configuration
{
    public enum SeedType
    {
        None = 0,
        Incremental,
        Full
    }

    public class DatabaseInitializationOptions
    {
        public DbContextInitializationOptions BlissAcademy { get; set; } = new DbContextInitializationOptions();
    }

    public class DbContextInitializationOptions
    {
        public bool MigrationsEnabled { get; set; } = false;

        public SeedType SeedType { get; set; } = SeedType.None;
    }
}
