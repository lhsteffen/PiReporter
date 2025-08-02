using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace MauiApp1
{
    public class DeviceTester
    {
        private string address;
        public string name { get; set; }
        private int interval = 5000;
        public string status { get; set; } = "pending";
        public Color color { get; set; } = new Color(200, 200, 200);
        public DeviceTester(string hostnameOrAddress, string name, int interval = 5000)
        {
            // Check if entered hostnameOrAddress is a domain name, and if so, is it valid
            if (Uri.CheckHostName(hostnameOrAddress) == UriHostNameType.Dns)
            {
                this.address = hostnameOrAddress;
            }
            else
            {
                // Check to ensure entered IP address is valid formatting
                IPAddress ipaddr;
                if (IPAddress.TryParse(hostnameOrAddress, out ipaddr))
                {
                    switch (ipaddr.AddressFamily)
                    {
                        case System.Net.Sockets.AddressFamily.InterNetwork:
                            this.address = hostnameOrAddress;
                            break;
                        case System.Net.Sockets.AddressFamily.InterNetworkV6:
                            this.address = hostnameOrAddress;
                            break;
                        default:
                            throw new ArgumentException("Invalid IP address or domain \"" + hostnameOrAddress + "\"", nameof(hostnameOrAddress));
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid IP address or domain \"" + hostnameOrAddress + "\"", nameof(hostnameOrAddress));
                }
            }

            // Set remaining Instance Variables
            this.name = name;
            this.interval = interval;
        }

        public bool pingDevice()
        {
            try
            {
                using (Ping p = new Ping())
                {
                    PingReply reply = p.Send(this.address);
                    if (reply.Status == IPStatus.Success)
                    {
                        this.status = "active";
                        this.color = new Color(0, 255, 0); // Green
                    } else
                    {
                        this.status = "inactive";
                        this.color = new Color(255, 0, 0); // Red
                    }
                        return reply.Status == IPStatus.Success;
                }
            } catch (PingException)
            {
                return false;
            }
        }

        public string logTester()
        {
            //if (this.logger != null)
            //{
            //    this.logger.writeLog("Name: " + this.name + " Address: " + this.address, "INFO");
            //}
            return "Name: " + this.name + " Address: " + this.address;
        }

        public string getAddress()
        {
            return this.address;
        }

        public string getName()
        {
            return this.name;
        }

        public string getStatus()
        {
            return this.status;
        }

        public int getInterval()
        {
            return this.interval;
        }

        public void setAddress(string address)
        {
            this.address = address;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setInterval(int interval)
        {
            this.interval = interval;
        }
    }
}
