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
	public partial class LessonFiveView : ContentPage
	{
        LessonFiveViewModel lessonFiveVM;
        public int _lessonValue;

        public LessonFiveView(int lessonValue)
        {
            lessonFiveVM = new LessonFiveViewModel(lessonValue);
            _lessonValue = lessonValue;

            InitializeComponent();

            BindingContext = lessonFiveVM;
        }
    }
}