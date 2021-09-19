using Application.Interfaces.Contexts;
using Entity.DBEntities;
using Microsoft.EntityFrameworkCore;
using Peristence.Context.Seeds;
using System;
using System.Configuration;

namespace Peristence.Context
{
    public class SiteDbContext : DbContext, ISiteDbContext
    {
        public DbSet<EntRole> Roles { set; get; }
        public DbSet<EntUser> Users { set; get; }
        public DbSet<EntLogin> Logins { set; get; }
        public DbSet<EntTopic> Topics { set; get; }
        public DbSet<EntPost> Posts { set; get; }



        public SiteDbContext(DbContextOptions options) : base(options)
        {

        }
        private static string GetConnectionString(string connectionStringName)
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (connectionStringSettings == null)
                throw new InvalidOperationException("Connection string \"" + connectionStringName + "\" could not be found in the configuration file.");
            return connectionStringSettings.ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
             * Set Collations
             * SetConnection
                optionsBuilder.UseSqlServer(GetConnectionString("ParsersConnectionString"));
             */
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             * set CCollations
             * Entities Mapping 
             * Relations Mapping
             * Seeds
             */
            modelBuilder.UseCollation("Persian_100_CI_AI");
            Seed(modelBuilder);
        }
        private static void Seed(ModelBuilder modelBuilder)
        {
            SeedTools.RolesSeed(modelBuilder);
            SeedTools.UsersSeed(modelBuilder);
            SeedTools.TopicsSeed(modelBuilder);
            SeedTools.Posts(modelBuilder);
        }
    }
}