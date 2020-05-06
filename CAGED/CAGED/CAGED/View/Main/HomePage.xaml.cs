using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAGED.Model;
using CAGED.View.Login;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace CAGED.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : Xamarin.Forms.TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }

        // Method is called when userpresses toolbar item, finds the current user
        // then updates currentUser parameter and returns to login 
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<RegisterModel>();

                var updateCurrentUser = conn.ExecuteScalar<RegisterModel>("UPDATE RegisterModel SET CurrentUser = ? " +
                    "WHERE CurrentUser = ?", "false", "true");


                App.Current.MainPage.DisplayAlert("Success", "User Logged Out", "OK");

            }

            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
    }
}