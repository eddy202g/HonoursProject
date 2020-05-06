using CAGED.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CAGED.View.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterView : ContentPage
    {
        RegisterViewModel regVM;

        public RegisterView()
        {
            regVM = new RegisterViewModel();
            InitializeComponent();

            BindingContext = regVM;
        }

    }
}