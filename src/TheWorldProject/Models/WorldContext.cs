using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TheWorldProject.Models
{
    public class WorldContext : DbContext
    {
        //private IConfigurationRoot _config;
        //public WorldContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        public WorldContext(DbContextOptions<WorldContext> options) : base(options)
        {
            //_config = config;
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        //{
        //    base.OnConfiguring(optionBuilder);

        //    optionBuilder.UseSqlServer(_config["ConnectionStrings:WorldContextConnection"]);
        //}
    }
}
