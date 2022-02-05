using Microsoft.EntityFrameworkCore;
using ResortForecaster.Models;

namespace ResortForecaster.Repos
{

    public class ResortForecasterContext : DbContext
    {

        public ResortForecasterContext(DbContextOptions<ResortForecasterContext> options) : base(options)
        {
        }

        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<SkiResort> SkiResorts { get; set; }
        public DbSet<FavoriteSkiResort> FavoriteSkiResorts { get; set; }
        public DbSet<Avalanche> Avalanches { get; set; }
    }
}
