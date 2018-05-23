using LocationProvider.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationProvider.DataAccess
{
    public class GeofenceDataService
    {

        public List<Geofence> GetAll()
        {
            using (var context = new LocationProviderContext())
            {
                return context.Geofence.ToList();
            }
        }

        public Geofence Get(int id)
        {
            using (var context = new LocationProviderContext())
            {
                return context.Geofence.FirstOrDefault(a => a.GeofenceId == id);
            }
        }


        public void Add(Geofence geofence)
        {
            using (var context = new LocationProviderContext())
            {
                context.Geofence.AddOrUpdate(geofence);
                context.SaveChanges();
            }
        }

        public void Update(int id, float north, float south, float east, float west)
        {
            using (var context = new LocationProviderContext())
            {
                var device = context.Device.FirstOrDefault(a => a.DeviceId == id);

                device.Geofence.North = north;
                device.Geofence.South = south;
                device.Geofence.East = east;
                device.Geofence.West = west;

                context.Device.AddOrUpdate(device);

                context.SaveChanges();
            }
        }

        public void Remove(Geofence geofence)
        {
            using (var context = new LocationProviderContext())
            {
                context.Geofence.Remove(geofence);
                context.SaveChanges();
            }
        }

    }
}
