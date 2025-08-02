using MauiApp1.ViewModels;
using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        DevicesViewModel ViewModel => BindingContext as DevicesViewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new DevicesViewModel();
        }

        private async void OnAddDeviceClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AddDevicePage");
        }

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //    count += 10;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}
    }

}
