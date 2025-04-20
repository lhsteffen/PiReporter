using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    class Logger
    {
        private string logfile;

        public Logger(string filename)
        {
            this.logfile = filename;
            //try
            //{
            //    using (FileStream fs = File.Create(this.logfile))
            //    {
            //        DateTime dateTime = DateTime.Now;
            //        byte[] topline = new UTF8Encoding(true).GetBytes("PiDashboard Log - " + dateTime.ToString(new CultureInfo("en-US")) + "\n");
            //        fs.Write(topline, 0, topline.Length);
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }

        public void newLog()
        {
            try
            {
                using (FileStream fs = File.Create(this.logfile))
                {
                    DateTime dateTime = DateTime.Now;
                    byte[] topline = new UTF8Encoding(true).GetBytes("PiDashboard Log - " + dateTime.ToString(new CultureInfo("en-US")) + "\n");
                    fs.Write(topline, 0, topline.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void writeLog(string message, string level)
        {
            try
            {
                using (FileStream fs = File.Open(this.logfile, FileMode.Append))
                {
                    DateTime time = DateTime.Now;
                    byte[] newline = new UTF8Encoding(true).GetBytes("[" + time.ToString(new CultureInfo("en-US")) + "] - " + level + " - " + message + "\n");
                    fs.Write(newline, 0, newline.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
