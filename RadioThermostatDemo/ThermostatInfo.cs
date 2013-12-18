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
    public partial class ThermostatInfo : Form
    {
        public ThermostatInfo()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void Populate(string ipAddress)
        {
            PopulateSystemInfo(ipAddress);
            PopulateNetworkInfo(ipAddress);
            PopulateServices(ipAddress);
            PopulateThermostatInfo(ipAddress);
        }

        private void PopulateThermostatInfo(string ipAddress)
        {
            Application.DoEvents();
            ThermostatLib.ThermostatInfo status = ThermostatLib.ThermostatInfo.Load(ipAddress);

            currentTemperatureLabel.Text = status.Temperature.ToString() + "°";
            ThermostatStateLabel.Text = status.ThermostatState;
            FanStateLabel.Text = status.FanState;

            if (status.TemporaryCool > 0)
            {
                SetTemperatureLabel.Text = status.TemporaryCool.ToString() + "°";
            }
            else
            {
                SetTemperatureLabel.Text = status.TemporaryHeat.ToString() + "°";
            }
            ThermostatModeLabel.Text = status.ThermostatMode;
            FanModeLabel.Text = status.FanMode;
            if (status.Hold) HoldLabel.Text = "Yes"; else HoldLabel.Text = "No";
            if (status.Override) OverrideLabel.Text = "Yes"; else OverrideLabel.Text = "No";
        }

        private void PopulateServices(string ipAddress)
        {
            Application.DoEvents();
            ThermostatLib.Services services=ThermostatLib.Services.Load(ipAddress);
            ServicesLabel.Text = "";
            foreach (ThermostatLib.HttpdHandler handler in services.Handlers)
            {
                ServicesLabel.Text += handler.Url + " (";
                if (handler.AllowsGet && handler.AllowsPost) ServicesLabel.Text += "GET, POST";
                else
                {
                    if (handler.AllowsGet) ServicesLabel.Text += "GET";
                    if (handler.AllowsPost) ServicesLabel.Text += "POST";
                }
                ServicesLabel.Text += ")" + System.Environment.NewLine;
            }
        }

        private void PopulateNetworkInfo(string ipAddress)
        {
            Application.DoEvents();
            ThermostatLib.NetworkConfiguration network = ThermostatLib.NetworkConfiguration.Load(ipAddress);
            BssidLabel.Text = network.BSSID;
            ChannelLabel.Text = network.Channel.ToString();
            if (network.DHCP)
            {
                DhcpLabel.Text = "Yes";
                IpAddressLabel.Text = "N/A - Static IP Only";
                GatewayLabel.Text = "N/A - Static IP Only";
                MaskLabel.Text = "N/A - Static IP Only";
                PrimaryDnsLabel.Text = "N/A - Static IP Only";
                SecondaryDnsLabel.Text = "N/A - Static IP Only";
            }
            else
            {
                DhcpLabel.Text = "No";
                IpAddressLabel.Text = network.IPAddress;
                GatewayLabel.Text = network.IPGateway;
                MaskLabel.Text = network.IPMask;
                PrimaryDnsLabel.Text = network.PrimaryDNS;
                SecondaryDnsLabel.Text = network.SecondaryDNS;
            }
            
            SecurityLabel.Text = network.Security.ToString();
            SignalStrengthLabel.Text = network.SignalStrength.ToString();
            SsidLabel.Text = network.SSID;
        }

        private void PopulateSystemInfo(string ipAddress)
        {
            Application.DoEvents();
            ThermostatLib.SystemInfo si = ThermostatLib.SystemInfo.Load(ipAddress);
            ApiLabel.Text = si.ApiVersion.ToString();
            FirmwareLabel.Text = si.FirmwareVersion;
            UuidLabel.Text = si.UUID;
            WlanLabel.Text = si.WlanFirmwareVersion;

            Application.DoEvents();
            ModelLabel.Text = ThermostatLib.SystemInfo.LoadModelName(ipAddress);

            Application.DoEvents();
            DeviceNameLabel.Text = ThermostatLib.SystemInfo.LoadSystemName(ipAddress);

            Application.DoEvents();
            OperatingModeLabel.Text = ThermostatLib.SystemInfo.LoadOperatingMode(ipAddress);
        }

        private void ThermostatInfo_Load(object sender, EventArgs e)
        {

        }


       

    }
}
