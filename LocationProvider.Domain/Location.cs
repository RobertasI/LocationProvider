
using System;
using System.Collections.Generic;

namespace LocationProvider.Domain
{
    public class Location
    {

        public int Id { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public DateTime TimeStamp { get; set; }

        public int DeviceId { get; set; }

        public Device Device { get; set; }
    }
}
