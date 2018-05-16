using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using LocationProvider.Domain;

namespace LocationProvider.DataAccess
{
    public class DeviceDataService
    {
        public List<Device> GetAll()
        {
            using (var context = new LocationProviderContext())
            {
                return context.Device.ToList();
            }
        }

        public Device Get(int id)
        {
            using (var context = new LocationProviderContext())
            {
                return context.Device.FirstOrDefault(a => a.DeviceId == id);
            }
        }

        public List<Device> GetDevicesByUserId(string userId)
        {
            using (var context = new LocationProviderContext())
            {
                var user = context.User.FirstOrDefault(a => a.UserId == userId);

                List<Device> relatedList = new List<Device>();

                var deviceList = context.Device.ToList();

                foreach (var device in deviceList)
                {
                    if (device.User.Id == user.Id)
                    {
                        relatedList.Add(device);
                    }
                }

                return relatedList;
            }
        }

        public void Add(Device device)
        {
            using (var context = new LocationProviderContext())
            {
                context.Device.AddOrUpdate(device);
                context.SaveChanges();
            }
        }

        public void AddLocation(int id, Location location)
        {
            using (var context = new LocationProviderContext())
            {
                var device = context.Device.FirstOrDefault(a => a.DeviceId == id);
                context.Set<Device>().Attach(device);
                device.Locations.Add(location);
                context.SaveChanges();
            }
        }

        public void Update(Device device)
        {
            using (var context = new LocationProviderContext())
            {
                context.Device.AddOrUpdate(device);
                context.SaveChanges();
            }
        }

        public void Remove(Device device)
        {
            using (var context = new LocationProviderContext())
            {
                context.Device.Remove(device);
                context.SaveChanges();
            }
        }
    }
}
