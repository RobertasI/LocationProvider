using System.Collections.Generic;

namespace LocationProvider.Domain
{
    public class Device
    {
        public Geofence geofence;

        public int Id { get; set; }

        public int DeviceId { get; set; }

        public string Title { get; set; }

        public virtual List<Location> Locations { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public virtual Geofence Geofence { get; set; }
    }
}
