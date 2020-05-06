using CAGED.Model;
using CAGED.View;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CAGED
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AchievementsPage : ContentPage
	{

        CourseModel deleteCourse = new CourseModel();

        public AchievementsPage ()
		{
            InitializeComponent();

            QueryIfCourseExists();


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            QueryIfCourseExists();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<CourseModel>();
                var posts = conn.Table<CourseModel>().ToList();
                postListView.ItemsSource = posts;
            }
        }

        private void PostListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            deleteCourse = (CourseModel)e.SelectedItem;
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.Table<CourseModel>().Delete(x => x.CourseID == deleteCourse.CourseID);
                conn.ExecuteScalar<CourseModel>("UPDATE sqlite_sequence SET seq = ?", 1);
                await Navigation.PushAsync(new HomePage());
            }
        }


        private void QueryIfCourseExists()
        {


            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var myquery = conn.Table<RegisterModel>().ToList();
                //Write code if table exists 

                foreach (var rootObject in myquery)
                {

                    if (rootObject.CurrentUser == "true" && rootObject.IsAdmin == true)
                    {
                        adminStack.IsVisible = true;
                        userStack.IsVisible = false;
                    }

                    if (rootObject.CurrentUser == "true" && rootObject.IsAdmin == false)
                    {
                        adminStack.IsVisible = false;
                        userStack.IsVisible = true;
                    }
                }

            }
        }
    }
}