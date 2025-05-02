using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public ObservableCollection<DeviceTester> Devices { get; set; }
        DeviceTesterList dtlist { get; set; }
        Logger logger;

        public MainPage()
        {
            InitializeComponent();
            //this.logger = new Logger("C:\\Users\\lhste\\Projects\\PiReporter\\Dashboard\\PiDashboard\\MauiApp1\\Logs\\application.log");
            //this.logger.newLog();
            //Devices = new ObservableCollection<DeviceTester>();
            //DeviceTester d1 = new DeviceTester("8.8.8.8", "Google DNS", logger);
            //DeviceTester d2 = new DeviceTester("google.com", "Google Main Page", logger);
            //Devices.Add(d1);
            //Devices.Add(d2);
            //this.logger.writeLog("Added 2 devices to the ObservableCollection", "INFO");
;            //dtlist.addTester(new DeviceTester("8.8.8.8", "Google DNS", logger));
            //dtlist.addTester(new DeviceTester("google.com", "Google Main Page", logger));
            //foreach (DeviceTester tester in dtlist.getTesters()) 
            //{
            //    Devices.Add(tester);
            //}
            //BindingContext = this;
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
