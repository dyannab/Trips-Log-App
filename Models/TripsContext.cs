using Microsoft.EntityFrameworkCore;

namespace Trips_Log_App.Models
{
    public class TripsContext(DbContextOptions<TripsContext> options) : DbContext(options)
    {
        public DbSet<Trip> Trips => Set<Trip>();




    }
}
