using LocationProvider.Domain;
using System.Web.Mvc;
using LocationProvider.DataAccess;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System;

namespace LocationProviderWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //---------------------------------------------------------------------------
            //DeviceDataService ddd = new DeviceDataService();

            //Device device = new Device
            //{
            //    DeviceId = 2,
            //    Title = "Samsung S7",
            //    UserId = 1,
            //    Locations = new List<Location>
            //     {
            //        new Location
            //        {
            //            Latitude = (float)54.697157,
            //            Longitude = (float)25.289652,
            //            TimeStamp = DateTime.Now
            //        }
            //    }
            //};
            //ddd.Add(device);

            //---------------------------------------------------------------------------
            //UserDataService uds = new UserDataService();

            //User user = new User
            //{
            //    UserId = "41dfa26f-b163-4e2d-ad87-61aea0372c2f",
            //    Name = "Robertas",
            //    Surname = "Ilginis",

            //    Devices = new List<Device>
            //    {
            //        new Device
            //        {
            //            DeviceId = 1,
            //            Title = "Sony Xperia Z2",

            //            Locations = new List<Location>
            //            {
            //                new Location
            //                {
            //                    Latitude = (float)54.687157,
            //                    Longitude = (float)25.279652,
            //                    TimeStamp = DateTime.Now
            //                }
            //            }
            //        }
            //    }
            //};

            //uds.Add(user);
            //---------------------------------------------------------------------------
            //LocationDataService lds = new LocationDataService();
            //Location location = new Location
            //{
            //    Latitude = (float)54.667157,
            //    Longitude = (float)25.319652,
            //    TimeStamp = DateTime.Now,
            //    DeviceId = 2

            //};
            //lds.Add(location);

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}