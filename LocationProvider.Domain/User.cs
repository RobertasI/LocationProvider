using System.Collections.Generic;

namespace LocationProvider.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public virtual List<Device> Devices { get; set; }

    }
}