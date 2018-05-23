using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationProvider.Domain
{
    public class Geofence
    {
        [ForeignKey("Device")]
        public int GeofenceId { get; set; }

        public float North { get; set; }

        public float South { get; set; }

        public float East { get; set; }

        public float West { get; set; }

        public virtual Device Device { get; set; }

    }
}
