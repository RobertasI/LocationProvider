using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocationProviderWeb.Api
{
    public class LocationModel
    {
        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public DateTime TimeStamp { get; set; }

        public int DeviceId { get; set; }
    }
}