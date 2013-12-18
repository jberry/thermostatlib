using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RadioThermostatDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            ThermostatInfo ti = new ThermostatInfo();
            ti.Show();
            ti.Populate(ipText.Text);
        }

        private void SetLedButton_Click(object sender, EventArgs e)
        {
            ThermostatLib.SystemInfo.SetLED(ipText.Text, "Green");
        }

        private void PriceButton_Click(object sender, EventArgs e)
        {
            ThermostatLib.SystemInfo.SetPriceMessage(ipText.Text, "123.45");
        }

        private void SystemNameButton_Click(object sender, EventArgs e)
        {
            ThermostatLib.SystemInfo.SetSystemName(ipText.Text, "Downstairs");
        }

        private void RebootButton_Click(object sender, EventArgs e)
        {
            ThermostatLib.SystemInfo.Reboot(ipText.Text);
        }

        private void CoolButton_Click(object sender, EventArgs e)
        {
            ThermostatLib.ThermostatInfo.SetTemporaryCool(ipText.Text, 70);
        }

        private void HeatButton_Click(object sender, EventArgs e)
        {
            ThermostatLib.ThermostatInfo.SetTemporaryHeat(ipText.Text, 80);
        }

        private void AutoButton_Click(object sender, EventArgs e)
        {
            //Not currently working
            //ThermostatLib.ThermostatInfo.SetAbsoluteTarget(ipText.Text, 75, 80);
        }

        private void LoadProgramButton_Click(object sender, EventArgs e)
        {
            ThermostatLib.Program program=ThermostatLib.Program.Load(ipText.Text,"cool");
            StringBuilder sb = new StringBuilder();

            foreach (ThermostatLib.ProgramEntry entry in program)
            {
                sb.Append(entry.DayOfWeek + " at " + entry.EntryTime.ToString("hh:mm tt").ToLower() + " - " + entry.Degrees + System.Environment.NewLine);
            }
            MessageBox.Show(sb.ToString());

        }

        private void SetProgramButton_Click(object sender, EventArgs e)
        {
            DateTime time1=DateTime.Today.AddHours(6);
            DateTime time2=DateTime.Today.AddHours(8);
            DateTime time3=DateTime.Today.AddHours(17);
            DateTime time4=DateTime.Today.AddHours(22);
            ThermostatLib.Program.SimpleSchedule(ipText.Text, "cool", time1, 75, time2, 77, time3, 75, time4, 77);
        }
    }
}
