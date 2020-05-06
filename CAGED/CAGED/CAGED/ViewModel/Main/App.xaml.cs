using CAGED.View.Login;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CAGED
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjA4MTg1QDMxMzcyZTM0MmUzMEZvSktiajhHeWZPazM4c0FtYUQ4bVhINHQreDlMcFovbWQxUWUwcnFYMTA9");

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databaseLocation)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjA4MTg1QDMxMzcyZTM0MmUzMEZvSktiajhHeWZPazM4c0FtYUQ4bVhINHQreDlMcFovbWQxUWUwcnFYMTA9");

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            DatabaseLocation = databaseLocation;

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
