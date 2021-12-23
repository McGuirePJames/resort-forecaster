using Microsoft.EntityFrameworkCore;
using ResortForecaster.Models;

namespace ResortForecaster.Repos
{
    public class ResortForecasterContext : DbContext
    {

        public ResortForecasterContext(DbContextOptions<ResortForecasterContext> options) : base(options)
        {
        }

        public DbSet<SkiResort> SkiResorts { get; set; }
        public DbSet<FavoriteSkiResort> FavoriteSkiResorts { get; set; }
    }
}
