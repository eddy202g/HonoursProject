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
	public partial class LessonTwoView : ContentPage
	{
        LessonTwoViewModel lessonTwoVM;
        public int _lessonValue;

        public LessonTwoView (int lessonValue)
		{
            lessonTwoVM = new LessonTwoViewModel(lessonValue);
            _lessonValue = lessonValue;

            InitializeComponent();

            BindingContext = lessonTwoVM;
        }
	}
}