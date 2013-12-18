using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ThermostatLib
{
    


    public class ThermostatInfo
    {
        #region Properties
        /// <summary>Current Temperature in Fahrenheit</summary>
        public double Temperature;

        /// <summary>The mode the thermostat is set to.  See ThermostatState to see the mode the thermostat is in.</summary>
        public string ThermostatMode;

        /// <summary>The mode the fan is set to.  See FanState to see the mode the fan is in.</summary>
        public string FanMode;

        /// <summary>Is the thermostat program temporarily overridden</summary>
        public bool Override;

        /// <summary>Is the thermostat program permanently overridden</summary>
        public bool Hold;

        /// <summary>The teporary cooling temperature if override or hold is set.</summary>
        public double TemporaryCool;

        /// <summary>The teporary heating temperature if override or hold is set.</summary>
        public double TemporaryHeat;

        /// <summary>The mode the thermostat is current in.  See ThermostatMode to see the mode the thermostat is set to.</summary>
        public string ThermostatState;

        /// <summary>The mode the fan is current in.  See FanMode to see the mode the fan is set to.</summary>
        public string FanState;
        #endregion

        #region Methods
        public static ThermostatInfo Load(string ipAddress)
        {
            string json=Utils.GetUrlContents("http://" + ipAddress + "/tstat");
            Hashtable ht=(Hashtable)JSON.JsonDecode(json);
            ThermostatInfo result=new ThermostatInfo();
            result.Temperature=Convert.ToDouble(ht["temp"]);
            switch (Convert.ToInt32(ht["tmode"]))
            {
                case 0:
                    result.ThermostatMode="Off";
                    break;
                case 1:
                    result.ThermostatMode="Heat";
                    break;
                case 2:
                    result.ThermostatMode="Cool";
                    break;
                case 3:
                    result.ThermostatMode="Auto";
                    break;
            }
            switch (Convert.ToInt32(ht["fmode"]))
            {
                case 0:
                    result.FanMode="Auto";
                    break;
                case 1:
                    result.FanMode = "Circulate";
                    break;
                case 2:
                    result.FanMode = "On";
                    break;
            }
            result.Override = Convert.ToBoolean(ht["override"]);
            result.Hold = Convert.ToBoolean(ht["hold"]);
            result.TemporaryHeat = Convert.ToInt32(ht["t_cool"]);
            result.TemporaryCool = Convert.ToInt32(ht["t_cool"]);


            switch (Convert.ToInt32(ht["tstate"]))
            {
                case 0:
                    result.ThermostatState = "Off";
                    break;
                case 1:
                    result.ThermostatState = "Heat";
                    break;
                case 2:
                    result.ThermostatState = "Cool";
                    break;
            }

            switch (Convert.ToInt32(ht["fstate"]))
            {
                case 0:
                    result.FanState = "Off";
                    break;
                case 1:
                    result.FanMode = "On";
                    break;
            }


            return result;

        }


        /// <summary>
        /// Sets the A/C on and to a temporary temperature
        /// </summary>
        /// <param name="degrees">Degress in Fahrenheit</param>
        public static void SetTemporaryCool(string ipAddress, double degrees)
        {
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("t_cool", degrees);
            string response = Utils.HttpPost("http://" + ipAddress + "/tstat", JSON.JsonEncode(ht));
        }

        /// <summary>
        /// Sets the heater on and to a temporary temperature
        /// </summary>
        /// <param name="degrees">Degress in Fahrenheit</param>
        public static void SetTemporaryHeat(string ipAddress, double degrees)
        {
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("t_heat", degrees);
            string response = Utils.HttpPost("http://" + ipAddress + "/tstat", JSON.JsonEncode(ht));
        }


        
        /// <summary>
        /// Sets both the heater and A/C to maintain the desired temperature range
        /// </summary>
        /// <param name="minDegrees">Temperature in Fahrenheit that the heater turns on.</param>
        /// <param name="maxDegrees">Temperature in Fahrenheit that the A/C turns on.</param>
        /*
        public static void SetAbsoluteTarget(string ipAddress, double minDegrees, double maxDegrees)
        {
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("a_heat", minDegrees);
            ht.Add("a_cool", minDegrees);
            ht.Add("a_mode", 1);
            string response = Utils.HttpPost("http://" + ipAddress + "/tstat", JSON.JsonEncode(ht));
        }
        */

        /// <summary>
        /// Toggles whether to hold the temporary temperature.
        /// </summary>
        /// <param name="enabled">True to hole, false to stop holding</param>
        public static void SetHold(string ipAddress, bool enabled)
        {
            int value = 0;
            if (enabled) value = 1;
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("hold", value);
            string response = Utils.HttpPost("http://" + ipAddress + "/tstat", JSON.JsonEncode(ht));
        }

        #endregion

    }


}
