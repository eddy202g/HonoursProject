using System;
using CAGED.View;
using CAGED.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CAGED.View.IntroCourse
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IntroOneView : ContentPage
    {
        IntroOneViewModel introOneVM;
        public int _lessonValue;

        public IntroOneView(int lessonValue)
        {
            
            introOneVM = new IntroOneViewModel(lessonValue);

            _lessonValue = lessonValue;

            InitializeComponent();
            BindingContext = introOneVM;
        }


        /*private async void Correct_Clicked(object sender, EventArgs e)
        {
            userGuess.Text = "logical ";

            await delayedWork();

            await App.Current.MainPage.DisplayAlert("Correct Answer", "\nGreat Work!", "OK");
            correct.IsVisible = false;
            incorrect.IsVisible = false;
            proceed.IsVisible = true;
        }

        private void Incorrect_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.DisplayAlert("Wrong Answer", "\nGive that another try...", "Try Again");
        }

        private async Task delayedWork()
        {
            await Task.Delay(1000);
        }

        private void Proceed_Clicked(object sender, EventArgs e)
        {
            part1.IsVisible = false;
            part2.IsVisible = true;
            ProgressBar.Progress = Convert.ToDouble("0.66");
        }

        private void Test_Clicked(object sender, EventArgs e)
        {
            Modal1 testModal = new Modal1("TEST", this);

            Navigation.PushModalAsync(testModal);

            part1.IsVisible = false;
            part2.IsVisible = false;
            part3.IsVisible = true;
            ProgressBar.Progress = Convert.ToDouble("1.00");
        }

        private void Complete_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }*/
    }
}