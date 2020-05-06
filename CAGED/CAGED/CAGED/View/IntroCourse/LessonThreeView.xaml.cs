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
	public partial class LessonThreeView : ContentPage
	{
        LessonThreeViewModel lessonThreeVM;
        public int _lessonValue;

        public LessonThreeView (int lessonValue)
		{
            lessonThreeVM = new LessonThreeViewModel(lessonValue);
            _lessonValue = lessonValue;

            InitializeComponent();

            BindingContext = lessonThreeVM;
        }
	}
}