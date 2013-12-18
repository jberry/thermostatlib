using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThermostatLib
{
    public class ProgramEntry
    {
        /// <summary>The day of the week in text form (Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday)</summary>
        public string DayOfWeek;
        /// <summary>The time of day for this entry.  Date is ignored</summary>
        public DateTime EntryTime;
        /// <summary>The set temperature in Fahrenheit</summary>
        public int Degrees;


        public ProgramEntry(string dayOfWeek, DateTime entryTime, int degrees)
        {
            DayOfWeek = dayOfWeek;
            EntryTime = entryTime;
            Degrees = degrees;
        }

    }
}
