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
            var locations = locationDataService.GetAllByDevice(id);

            return View(locations);
        }

        public ActionResult Sort(int id, int time)
        {
            DeviceDataService deviceDataService = new DeviceDataService();
            var device = deviceDataService.Get(id);
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
            var locations = locationDataService.GetAllByDevice(id);

            return View(locations[locations.Count - 1]);
        }

    }
}