using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using LocationProvider.Domain;

namespace LocationProvider.DataAccess
{
    public class LocationDataService
    {
        public List<Location> GetAll()
        {
            using (var context = new LocationProviderContext())
            {
                return context.Location.ToList();
            }
        }

        public Location Get(int id)
        {
            using (var context = new LocationProviderContext())
            {
                return context.Location.FirstOrDefault(a => a.Id == id);
            }
        }

        public List<Location> GetAllByDevice(int deviceId)
        {
            using (var context = new LocationProviderContext())
            {

                return context.Location.Where(x => x.DeviceId == deviceId).ToList();
            }
        }

        public void Add(Location Location)
        {
            using (var context = new LocationProviderContext())
            {
                context.Location.AddOrUpdate(Location);
                context.SaveChanges();
            }
        }

        public void Update(Location Location)
        {
            using (var context = new LocationProviderContext())
            {
                context.Location.AddOrUpdate(Location);
                context.SaveChanges();
            }
        }

        public void Remove(Location Location)
        {
            using (var context = new LocationProviderContext())
            {
                context.Location.Remove(Location);
                context.SaveChanges();
            }
        }
    }
}
