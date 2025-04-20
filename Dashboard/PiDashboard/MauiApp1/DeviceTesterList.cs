using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MauiApp1
{
    class DeviceTesterList
    {
        private List<DeviceTester> dtlist = new List<DeviceTester>();
        private Logger logger;

        public DeviceTesterList(DeviceTester dt, Logger logger)
        {
            this.dtlist.Add(dt);
            this.logger = logger;
        }

        public DeviceTesterList(string filename, Logger log)
        {
            this.logger = log;
            try
            {
                XDocument config = XDocument.Load(filename);
                foreach (XElement elem in config.Descendants("device"))
                {
                    try
                    {
                        if (elem.Element("address")?.Value != null)
                        {
                            this.dtlist.Add(new DeviceTester(elem.Element("address")?.Value, elem.Element("name")?.Value, this.logger));
                        }
                        else
                        {
                            this.logger.writeLog("Error adding new device, ignored", "ERROR");
                        }
                    }
                    catch (ArgumentException ae)
                    {
                        this.logger.writeLog(ae.Message, "ERROR");
                    }
                }

            }
            catch (XmlException xe)
            {
                this.logger.writeLog(xe.Message, "ERROR");
            }
            catch (FileNotFoundException fe)
            {
                this.logger.writeLog(fe.Message, "ERROR");
            }
        }

        public DeviceTesterList(Logger logger)
        {
            this.logger = logger;
        }

        public void addTester(DeviceTester dt)
        {
            this.dtlist.Add(dt);
        }

        public void removeTester(string address)
        {
            foreach (DeviceTester dt in this.dtlist)
            {
                if (dt.getAddress().Equals(address))
                {
                    this.dtlist.Remove(dt);
                }
            }
        }

        public DeviceTester getTester(int index)
        {
            return this.dtlist[index];
        }

        public List<DeviceTester> getTesters()
        {
            return this.dtlist;
        }

        public void logTesters()
        {
            foreach (DeviceTester dt in this.dtlist)
            {
                dt.logTester();
            }
        }
    }
}
