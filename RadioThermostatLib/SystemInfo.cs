using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ThermostatLib
{
    public class SystemInfo
    {
        #region Properties
        /// <summary>The unique identifier for this device (uuid)</summary>
        public string UUID;

        /// <summary>HTTP API version (api_version)</summary>
        public int ApiVersion;

        /// <summary>Firmware version (fw_version)</summary>
        public string FirmwareVersion;

        /// <summary>Underlying WLAN firmware version (wlan_fw_version)</summary>
        public string WlanFirmwareVersion;
        #endregion

        #region Methods
        public static SystemInfo Load(string ipAddress)
        {
            string json = Utils.GetUrlContents("http://" + ipAddress + "/sys");
            Hashtable ht = (Hashtable)JSON.JsonDecode(json);
            SystemInfo result = new SystemInfo();

            result.UUID = Convert.ToString(ht["uuid"]);
            result.ApiVersion = Convert.ToInt32(ht["api_version"]);
            result.FirmwareVersion = Convert.ToString(ht["fw_version"]);
            result.WlanFirmwareVersion = Convert.ToString(ht["wlan_fw_version"]);
            return result;
        }

        /// <summary>Returns display name for device (/sys/name)</summary>
        public static string LoadSystemName(string ipAddress)
        {
            string json = Utils.GetUrlContents("http://" + ipAddress + "/sys/name");
            Hashtable ht = (Hashtable)JSON.JsonDecode(json);
            return ht["name"].ToString();
        }

        /// <summary>Returns model name for device (/tstat/model)</summary>
        public static string LoadModelName(string ipAddress)
        {
            string json = Utils.GetUrlContents("http://" + ipAddress + "/tstat/model");
            Hashtable ht = (Hashtable)JSON.JsonDecode(json);
            return ht["model"].ToString();
        }

        /// <summary>Returns operating mode for device (/sys/mode)</summary>
        public static string LoadOperatingMode(string ipAddress)
        {
            string json = Utils.GetUrlContents("http://" + ipAddress + "/sys/mode");
            Hashtable ht = (Hashtable)JSON.JsonDecode(json);
            if (Convert.ToInt32(ht["mode"]) == 0) return "Provisioning"; else return "Normal";
        }


        /// <summary>
        /// Assigns the friendly name the system is identified as (/sys/name)
        /// </summary>
        /// <param name="name">The new name for the system</param>
        public static void SetSystemName(string ipAddress, string name)
        {
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("name", name);
            string response = Utils.HttpPost("http://" + ipAddress + "/sys/name", JSON.JsonEncode(ht));
        }


        /// <summary>
        /// Reboots the system (/sys/command)
        /// </summary>
        public static void Reboot(string ipAddress)
        {
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("command", "reboot");
            string response = Utils.HttpPost("http://" + ipAddress + "/sys/command", JSON.JsonEncode(ht));
        }

        /// <summary>
        /// Places the system back into provisioning mode (/sys/mode)
        /// </summary>
        public static void ReProvision(string ipAddress)
        {
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("mode", 0);
            string response = Utils.HttpPost("http://" + ipAddress + "/sys/mode", JSON.JsonEncode(ht));
        }


        /// <summary>
        /// Sets the LED state (/tstat/led)
        /// </summary>
        /// <param name="state">Values: Off, Green, Yellow, Red</param>
        public static void SetLED(string ipAddress, string state)
        {
            int value = 0;
            switch (state.ToLower())
            {
                case "green":
                    value = 1;
                    break;
                case "yellow":
                    value = 2;
                    break;
                case "red":
                    //doesn't work
                    value = 3;
                    break;
            }
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("energy_led", value);
            string parameters = JSON.JsonEncode(ht);
            string response = Utils.HttpPost("http://" + ipAddress + "/tstat/led", parameters);
        }

        /// <summary>
        /// Sets a custom message in the price area (/tstat/pma)
        /// </summary>
        /// <param name="message">The number to display.  Must be a number.</param>
        public static void SetPriceMessage(string ipAddress, string message)
        {
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("message", message);
            string response = Utils.HttpPost("http://" + ipAddress + "/tstat/pma", JSON.JsonEncode(ht));
        }

        #endregion



    }
}
