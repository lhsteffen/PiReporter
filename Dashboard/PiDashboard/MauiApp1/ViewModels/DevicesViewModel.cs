using CommunityToolkit.Mvvm.Messaging;
using MauiApp1.Messages;
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
    // Note: An object of this class is intialized by the MainPage.xaml file
    class DevicesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DeviceTester> Devices { get; set; }
        private Logger logger = new Logger("C:\\Users\\lhste\\Projects\\PiReporter\\Dashboard\\PiDashboard\\MauiApp1\\Logs\\application.log");
        private DeviceTesterList dtlist;

        public DevicesViewModel()
        {
            //Devices = new ObservableCollection<DeviceTester> { };
            //this.dtlist = new DeviceTesterList("C:\\Users\\lhste\\Projects\\PiReporter\\Dashboard\\PiDashboard\\MauiApp1\\Resources\\Data\\devices.xml", logger);
            //foreach (DeviceTester dt in dtlist.getTesters())
            //{
            //    Devices.Add(dt);
            //}

            //foreach (DeviceTester device in Devices)
            //{
            //    device.pingDevice();
            //}
            Devices = new ObservableCollection<DeviceTester> { };
            this.dtlist = new DeviceTesterList(Devices, "C:\\Users\\lhste\\Projects\\PiReporter\\Dashboard\\PiDashboard\\MauiApp1\\Resources\\Data\\devices.xml", logger);
            TestDevices();

            WeakReferenceMessenger.Default.Register<DeviceAddedMessage>(this, (r, m) =>
            {
                if (!string.IsNullOrWhiteSpace(m.Value?.getAddress()))
                {
                    this.dtlist.addTester(m.Value);
                    this.dtlist.pingTesters();
                }
            });
        }

        public void AddNewDevice(DeviceTester device)
        {
            this.dtlist.addTester(device);
        }

        public void RemoveDevice(DeviceTester device)
        {
            this.dtlist.removeTester(device.getAddress());
        }

        public void TestDevices()
        {
            foreach (DeviceTester device in this.dtlist.getTesters())
            {
                device.pingDevice();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
