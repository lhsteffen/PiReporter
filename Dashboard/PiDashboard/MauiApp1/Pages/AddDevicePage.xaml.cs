using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using MauiApp1.Messages;
using MauiApp1.ViewModels;

namespace MauiApp1
{
    public partial class AddDevicePage : ContentPage
    {
        public AddDevicePage()
        {
            InitializeComponent();
        }

        public async void OnSaveClicked(object sender, EventArgs e)
        {
            string host = HostEntry.Text;
            string name = NameEntry.Text;

            if (!string.IsNullOrWhiteSpace(host) && !string.IsNullOrWhiteSpace(name))
            {
                DeviceTester device = new DeviceTester(host, name);

                // Send Message
                WeakReferenceMessenger.Default.Send(new DeviceAddedMessage(device));

                // Close Page
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
