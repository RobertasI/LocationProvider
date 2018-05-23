using LocationProvider.DataAccess;
using LocationProvider.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace LocationProviderWeb.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            string userID = User.Identity.GetUserId();

            User user = new User
            {
                UserId = userID,
                Name = User.Identity.Name,
                Surname = User.Identity.Name,
            };

            UserDataService userDataService = new UserDataService();
            userDataService.AddNotExisting(userID, user);


            DeviceDataService deviceDataService = new DeviceDataService();

            var deviceList = deviceDataService.GetDevicesByUserId(userID);

            return View(deviceList);
        }

        public ActionResult AddDevice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Device(Device device)
        {

            UserDataService userDataService = new UserDataService();

            var user = userDataService.GetByUserId(User.Identity.GetUserId());

            DeviceDataService deviceDataService = new DeviceDataService();

            Device newDevice = new Device
            {
                DeviceId = device.DeviceId,
                Geofence = new Geofence
                {
                    North = 180,
                    South = -180,
                    East = 90,
                    West = -90,
                },
                Title = device.Title,
                UserId = user.Id

            };

            deviceDataService.Add(newDevice);


            return RedirectToAction("Index");
        }

    }
}