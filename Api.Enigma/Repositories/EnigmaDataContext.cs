using System;
using System.ComponentModel.DataAnnotations;
using Api.Enigma.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Api.Enigma.Repositories
{
    public class EnigmaDataContext : DbContext
    {

        public DbSet<ScoreEntity> Scores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
            string conn = configuration.GetConnectionString("EnigmaDB");
            options.UseSqlite(conn);
        }
    }
}
