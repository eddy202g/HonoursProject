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
	public partial class LessonOneView : ContentPage
	{
        LessonOneViewModel lessonOneVM;
        public int _lessonValue;

        public LessonOneView (int lessonValue)
		{
            lessonOneVM = new LessonOneViewModel(lessonValue);
            _lessonValue = lessonValue;

            InitializeComponent ();

            BindingContext = lessonOneVM;
        }
	}
}