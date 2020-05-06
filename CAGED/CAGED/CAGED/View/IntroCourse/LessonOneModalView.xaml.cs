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
	public partial class LessonOneModalView : ContentPage
	{
        private string v;
        private LessonOneViewModel lessonOneViewModel;

        LessonOneModalViewModel lessonOneModalVM;

        public LessonOneModalView (string v, LessonOneViewModel lessonOneViewModel)
		{
            this.v = v;
            this.lessonOneViewModel = lessonOneViewModel;
            InitializeComponent ();

            lessonOneModalVM = new LessonOneModalViewModel();
            InitializeComponent();
            BindingContext = lessonOneModalVM;
        }
	}
}