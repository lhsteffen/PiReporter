﻿namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            const int newHeight = 600;
            const int newWidth = 300;

            Window newWindow = new Window(new AppShell())
            {
                Height = newHeight,
                Width = newWidth
            };

            return newWindow;
        }
    }
}