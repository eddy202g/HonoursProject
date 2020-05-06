

using CAGED.ViewModel;
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
    public partial class CoursesPage : ContentPage
    {
        CoursesPageViewModel coursesPageViewModel;
        public CoursesPage()
        {
            coursesPageViewModel = new CoursesPageViewModel();

            InitializeComponent();

            BindingContext = coursesPageViewModel;

        }

        protected override void OnAppearing()
        {
            coursesPageViewModel.CheckCourseTableExists();
            coursesPageViewModel.ReadDatabase();
        }

        private void CourseOne_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("HELLO", "Button WORKS!", "OK");
        }

        private void CourseTwo_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("HELLO", "Button WORKS!", "OK");
        }

        private void CourseThree_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("HELLO", "Button WORKS!", "OK");
        }

        private void CourseFour_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("HELLO", "Button WORKS!", "OK");
        }



        //private void Intro_Clicked(object sender, EventArgs e)
        // {
        //     DynamicPageView.Children.Clear();
        //     DynamicPageView.Children.Add(new IntroView());
        // }


    }
}