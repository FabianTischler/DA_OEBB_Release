using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using OEBB_Pruefstand.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace OEBB_Pruefstand.Persistence
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<OEBBPruefer> Pruefer { get; set; }
        public DbSet<OEBBAntriebseinheit> Antriebseinheiten { get; set; }
        public DbSet<OEBBAntriebskomponenten> Antriebskomponenten { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            if (string.IsNullOrEmpty(connectionString))
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("appsettings.json", true, true);
                var configuration = builder.Build();
                connectionString = configuration["ConnectionStrings:DefaultConnection"];
            }
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
