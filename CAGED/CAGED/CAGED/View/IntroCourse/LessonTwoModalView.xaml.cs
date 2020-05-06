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
    public partial class LessonTwoModalView : ContentPage
    {
        private string v;
        private LessonTwoViewModel lessonTwoViewModel;

        LessonTwoModalViewModel lessonTwoModalVM;

        public LessonTwoModalView(string v, LessonTwoViewModel lessonTwoViewModel)
        {
            this.v = v;
            this.lessonTwoViewModel = lessonTwoViewModel;
            InitializeComponent();

            lessonTwoModalVM = new LessonTwoModalViewModel();
            InitializeComponent();
            BindingContext = lessonTwoModalVM;
        }
    }
}
