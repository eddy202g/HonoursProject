using CAGED.ViewModel.IntroCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CAGED.View.IntroCourse
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IntroAssessment : ContentPage
	{
        IntroAssessmentViewModel introAssVM;

        public IntroAssessment()
		{
            introAssVM = new IntroAssessmentViewModel();

            InitializeComponent();
            BindingContext = introAssVM;
        }
	}
}