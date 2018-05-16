using System.Data.Entity;
using LocationProvider.Domain;

namespace LocationProvider.DataAccess
{
    public class LocationProviderContext : DbContext
    {
        public DbSet<Device> Device { get; set; }

        public DbSet<Location> Location { get; set; }

        public DbSet<User> User { get; set; }

    }
}
