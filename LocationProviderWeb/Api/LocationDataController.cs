﻿using LocationProvider.Domain;
using LocationProviderWeb.Api;
using LocationProvider.DataAccess;
using System;
using System.Collections.Generic;
using System.Web.Http;
using PusherServer;
using LocationProviderWeb.Helpers;

namespace AttendanceService.WebApp.APIControllers
{
    public class LocationDataController : ApiController
    {
        private Pusher _pusher;

        [HttpPost]
        public IHttpActionResult AddLocation(LocationModel locatioModel)
        {

            // To call this method: http://localhost:12345/Api/LocationData/AddLocation

            DeviceDataService deviceDataService = new DeviceDataService();

            var device = deviceDataService.Get(locatioModel.DeviceId); 

            if (device == null)
            {
                return Json("Toks įrenginys neegzistuoja");
            }
            else
            {
                LocationDataService locationDataService = new LocationDataService();

                Location location = new Location
                {
                    Longitude = locatioModel.Longitude,
                    Latitude = locatioModel.Latitude,
                    TimeStamp = locatioModel.TimeStamp,
                    DeviceId = device.Id
                };

                locationDataService.Add(location);

                var jsonLocation = new
                {
                    latitude = locatioModel.Latitude,
                    longitude = locatioModel.Longitude
                };

                var options = new PusherOptions
                {
                    Cluster = "eu",
                    Encrypted = true
                };

                var _pusher = new Pusher(
                    "526323",
                    "e3eb2284cbb62f35599f",
                    "52decc2ad70da06be4d0",
                    options);


                _pusher.TriggerAsync("location_channel", "new_location", jsonLocation);

                GeofencingServices geofencingServices = new GeofencingServices();

                geofencingServices.CheckGeofence(locatioModel.Longitude, locatioModel.Latitude, locatioModel.DeviceId);

                return Json(new { status = "success", data = location });
            }
 
        }
    }
}
