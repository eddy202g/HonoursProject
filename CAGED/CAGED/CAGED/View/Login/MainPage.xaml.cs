using CAGED.Model;
using CAGED.ViewModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CAGED.View.Login
{
    public partial class MainPage : ContentPage
    {
        LoginViewModel loginViewModel;
        public MainPage()
        {
            loginViewModel = new LoginViewModel();
            InitializeComponent();
            BindingContext = loginViewModel;
        }

        protected override void OnAppearing()
        {
            loginViewModel.ReadDatabase();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
