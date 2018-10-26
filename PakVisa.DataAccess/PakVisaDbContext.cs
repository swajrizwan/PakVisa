using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PakVisa.Models;

namespace PakVisa.DataAccess
{
    public class PakVisaDbContext : DbContext
    {
        private readonly IConfigurationRoot _config;

        public PakVisaDbContext(DbContextOptions<PakVisaDbContext> options, IConfigurationRoot config)
            : base(options)
        {
            _config = config;
        }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<Userlogin> Userlogins { get; set; }
        public DbSet<VisaType> VisaTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["ConnectionString:PakVisaConnectionString"]);
        }

    }
}