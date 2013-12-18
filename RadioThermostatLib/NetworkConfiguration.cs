using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThermostatLib
{

    public class NetworkConfiguration
    {
        #region Properties
        /// <summary>Network Name (ssid)</summary>
        public string SSID;

        /// <summary>BSSID (bssid)</summary>
        public string BSSID;

        /// <summary>Channel (channel)</summary>
        public int Channel;

        /// <summary>Security mode (security)</summary>
        public int Security;

        /// <summary>Is using DHCP (ip)</summary>
        public bool DHCP;

        /// <summary>IP address - static only (ipaddr)</summary>
        public string IPAddress;

        /// <summary>IP mask - static only (ipmask)</summary>
        public string IPMask;

        /// <summary>Gateway - static only (ipgw)</summary>
        public string IPGateway;

        /// <summary>Primary DNS Server - static only (ipdns1)</summary>
        public string PrimaryDNS;

        /// <summary>Secondary DNS Server - static only (ipdns2)</summary>
        public string SecondaryDNS;

        /// <summary>Signal Strength (rssi)</summary>
        public int SignalStrength;
        #endregion

        public static NetworkConfiguration Load(string ipAddress)
        {
            string json = Utils.GetUrlContents("http://" + ipAddress + "/sys/network");
            Hashtable ht = (Hashtable)JSON.JsonDecode(json);
            NetworkConfiguration result = new NetworkConfiguration();

            result.SSID = Convert.ToString(ht["ssid"]);
            result.BSSID = Convert.ToString(ht["bssid"]);
            result.Channel = Convert.ToInt32(ht["channel"]);
            result.Security = Convert.ToInt32(ht["security"]);
            result.DHCP = Convert.ToBoolean(ht["ip"]);
            result.SignalStrength = Convert.ToInt32(ht["rssi"]);
            return result;
        }

    }
}
