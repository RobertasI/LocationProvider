using LocationProvider.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace LocationProviderWeb.Helpers
{
    public class GeofencingServices
    {
        public void CheckGeofence(float latitude, float longitude, int devideId)
        {
            DeviceDataService deviceDataService = new DeviceDataService();

            var device = deviceDataService.Get(devideId);

            if (latitude > device.Geofence.North || latitude < device.Geofence.South || longitude > device.Geofence.East || longitude < device.Geofence.West)
            {
                SendEmail(device.Title);
            }
            return;
        }

        public void SendEmail(string title)
        {
            //MailMessage o = new MailMessage("ilginis.robertas@gmail.com", "robertas.ilginis@stud.vgtu.lt", "Subject", title);
            //NetworkCredential netCred = new NetworkCredential("admin@admin.lt", "admin");
            //SmtpClient smtpobj = new SmtpClient("smtp.live.com", 587);
            //smtpobj.EnableSsl = true;
            //smtpobj.Credentials = netCred;
            //smtpobj.Send(o);

            //send email
        }
    }
}