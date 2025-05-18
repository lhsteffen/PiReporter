using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    class DevicesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DeviceTester> Devices { get; set; }
        private Logger logger = new Logger("C:\\Users\\lhste\\Projects\\PiReporter\\Dashboard\\PiDashboard\\MauiApp1\\Logs\\application.log");

        public DevicesViewModel()
        {
            Devices = new ObservableCollection<DeviceTester>
            {
                new DeviceTester("8.8.8.8", "Google DNS", logger),
                new DeviceTester("google.com", "Google Main Page", logger)
            };

            foreach (DeviceTester device in Devices)
            {
                device.pingDevice();
            }
        }

        public void AddNewDevice(DeviceTester device)
        {
            this.Devices.Add(device);
        }

        public void RemoveDevice(DeviceTester device)
        {
            this.Devices.Remove(device);
        }

        public void TestDevices()
        {
            foreach (DeviceTester device in this.Devices)
            {
                device.pingDevice();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
