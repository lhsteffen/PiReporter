namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Route Registration
            Routing.RegisterRoute(nameof(AddDevicePage), typeof(AddDevicePage));
        }
    }
}
