using LocationProvider.DataAccess;
using LocationProvider.Domain;
using PusherServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LocationProviderWeb.Controllers
{
    public class MapController : Controller
    {

        public ActionResult Index(int id)
        {
            DeviceDataService deviceDataService = new DeviceDataService();
            var device = deviceDataService.Get(id);
            LocationDataService locationDataService = new LocationDataService();
            var locations = locationDataService.GetAllByDevice(device.Id);

            if (locations.Count == 0)
            {
                return View("NoLocationsAvailable");
            }
            else
            {
                return View(locations);
            }
 
        }

        public ActionResult Sort(int id, int time)
        {

            LocationDataService locationDataService = new LocationDataService();
            var locations = locationDataService.GetAllByDevice(id);

            List<Location> sortedList = new List<Location>();

            var now = DateTime.Now;
            foreach (var location in locations)
            {
                if((now - location.TimeStamp).TotalMinutes <= (time*60))
                {
                    sortedList.Add(location);
                }
            }
            //if no sorting can be made by that time, the last known place is shown
            if (sortedList.Count == 0)
            {
                sortedList.Add(locations[locations.Count - 1]);
            }
            
            return View("Index", sortedList);
        }

        public ActionResult RealTime(int id)
        {
            DeviceDataService deviceDataService = new DeviceDataService();
            var device = deviceDataService.Get(id);

            LocationDataService locationDataService = new LocationDataService();
            var locations = locationDataService.GetAllByDevice(device.Id);

            if (locations.Count == 0)
            {
                return View("NoLocationsAvailable");
            }
            else
            {
                return View(locations[locations.Count - 1]);
            }

        }

        public ActionResult Geofence(int id)
        {
            DeviceDataService deviceDataService = new DeviceDataService();
            var device = deviceDataService.Get(id);

            return View(device);
        }

        [HttpPost]
        public ActionResult SetGeofence(int Id, float North, float South, float East, float West)
        {
            GeofenceDataService geofencedataservice = new GeofenceDataService();

            geofencedataservice.Update(Id, North, South, East, West);

            return Json(new { newUrl = Url.Action("Index", "Client") });
        }

    }
}