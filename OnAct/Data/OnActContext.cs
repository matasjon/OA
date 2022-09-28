using Microsoft.EntityFrameworkCore;
using OnAct.Data.Entities;

namespace OnAct.Data
{
    public class OnActContext : DbContext
    {
        
        public DbSet<Activity> Activities { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<Group> Groups { get; set; }

        protected readonly IConfiguration Configuration;

        public OnActContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }


    }
}
