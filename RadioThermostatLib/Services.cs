using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThermostatLib
{
    public class Services
    {
        /// <summary>A list of the service names on the device. (service_names)</summary>
        public string[] ServiceNames;

        /// <summary>A list of the URIs available (httpd_handlers)</summary>
        public HttpdHandlers Handlers;

        public static Services Load(string ipAddress)
        {
            string json = Utils.GetUrlContents("http://" + ipAddress + "/sys/services");
            Hashtable ht = (Hashtable)JSON.JsonDecode(json);
            Services result = new Services();

            ArrayList services=(ArrayList)ht["service_names"];
            result.ServiceNames=new string[services.Count];
            for (int i = 0; i < services.Count; i++)
            {
                result.ServiceNames[i] = services[i].ToString();
            }


            Hashtable handlers = (Hashtable)ht["httpd_handlers"];
            result.Handlers = new HttpdHandlers();
            foreach (string key in handlers.Keys)
            {
                HttpdHandler handler = new HttpdHandler();
                handler.Url = key;
                ArrayList values=(ArrayList)handlers[key];
                handler.AllowsGet = Convert.ToBoolean(values[0]);
                handler.AllowsPost = Convert.ToBoolean(values[1]);
                result.Handlers.Add(handler);
            }
            return result;
        }


    }
}
