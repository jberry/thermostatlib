using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThermostatLib
{
    public class Program:List<ProgramEntry>
    {
        #region PublicMethods

        /// <summary>
        /// Loads the current heat or cool schedule
        /// </summary>
        /// <param name="mode">heat or cool</param>
        /// <returns></returns>
        public static Program Load(string ipAddress,string mode)
        {
            mode = mode.ToLower();
            if (mode != "heat" && mode != "cool") throw new Exception("Mode must be heat or cool.");
            string json = Utils.GetUrlContents("http://" + ipAddress + "/tstat/program/" + mode);
            Hashtable ht = (Hashtable)JSON.JsonDecode(json);

            Program result = new Program();
            for (int i = 0; i < 7; i++)
            {
                result.DecodeDay(i, (ArrayList)ht[i.ToString()]);
            }
            return result;
        }

        /// <summary>
        /// Saves the current schedule to the device
        /// </summary>
        /// <param name="mode">heat or cool</param>
        public void Save(string ipAddress, string mode)
        {
            if (mode != "heat" && mode != "cool") throw new Exception("Mode must be heat or cool.");
            Hashtable ht = new Hashtable();
            EncodeDay(ht, "Sunday");
            EncodeDay(ht, "Monday");
            EncodeDay(ht, "Tuesday");
            EncodeDay(ht, "Wednesday");
            EncodeDay(ht, "Thursday");
            EncodeDay(ht, "Friday");
            EncodeDay(ht, "Saturday");
            string response = Utils.HttpPost("http://" + ipAddress + "/tstat/program/" + mode, JSON.JsonEncode(ht));
        }

        /// <summary>
        /// Creates a single schedule for the whole week.
        /// </summary>
        public static void SimpleSchedule(string ipAddress, string mode, DateTime time1, int temp1, DateTime time2, int temp2, DateTime time3, int temp3, DateTime time4, int temp4)
        {
            string[] daysOfWeek = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            Program program = new Program();

            foreach (string dayOfWeek in daysOfWeek)
            {
                program.Add(new ProgramEntry(dayOfWeek,time1,temp1));
                program.Add(new ProgramEntry(dayOfWeek,time2,temp2));
                program.Add(new ProgramEntry(dayOfWeek,time3,temp3));
                program.Add(new ProgramEntry(dayOfWeek,time4,temp4));
            }
            program.Save(ipAddress, mode);
        }
        #endregion

        #region Private Methods
        private Program GetByDayOfWeek(string dayOfWeek)
        {
            Program result=new Program();
            foreach (ProgramEntry entry in this)
            {
                if (entry.DayOfWeek.ToLower()==dayOfWeek.ToLower()) result.Add(entry);
            }
            return result;
        }


        private void EncodeDay(Hashtable ht, string dayOfWeek)
        {
            Program entries=GetByDayOfWeek(dayOfWeek);
            if (entries.Count==0) return;

            int day=0;
            switch (dayOfWeek.ToLower())
            {
                case "monday":
                    day=1;
                    break;
                case "tuesday":
                    day=2;
                    break;
                case "wednesday":
                    day=3;
                    break;
                case "thursday":
                    day=4;
                    break;
                case "friday":
                    day=5;
                    break;
                case "saturday":
                    day=6;
                    break;
            }


            ArrayList array = new ArrayList();
            for (int i=0;i<entries.Count;i++)
            {
                array.Add(entries[i].EntryTime.Hour * 60 + entries[i].EntryTime.Minute);
                array.Add(entries[i].Degrees);
            }
            ht.Add(day.ToString(),array);
        }



        private void DecodeDay(int day, ArrayList values)
        {
            string dayOfWeek="";
            switch (day)
            {
                case 0:
                    dayOfWeek = "Sunday";
                    break;
                case 1:
                    dayOfWeek = "Monday";
                    break;
                case 2:
                    dayOfWeek = "Tuesday";
                    break;
                case 3:
                    dayOfWeek = "Wednesday";
                    break;
                case 4:
                    dayOfWeek = "Thursday";
                    break;
                case 5:
                    dayOfWeek = "Friday";
                    break;
                case 6:
                    dayOfWeek = "Saturday";
                    break;
            }

            for (int i = 0; i < values.Count; i = i + 2)
            {
                int minutes = Convert.ToInt32(values[i]);
                DateTime time = DateTime.Today.AddMinutes(minutes);
                int degrees = Convert.ToInt32(values[i + 1]);
                this.Add(new ProgramEntry(dayOfWeek, time, degrees));
            }
        }
        #endregion

    }
}
