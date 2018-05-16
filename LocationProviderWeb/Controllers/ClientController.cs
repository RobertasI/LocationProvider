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

            DeviceDataService deviceDataService = new DeviceDataService();

            var deviceList = deviceDataService.GetDevicesByUserId(userID);

            return View(deviceList);
        }

    }
}