﻿using Microsoft.EntityFrameworkCore;

namespace Probleaufgabe.API.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Device> Devices { get; set; }
    }
}
